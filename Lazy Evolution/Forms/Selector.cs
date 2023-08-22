/*
This file is part of LazyBot - Copyright (C) 2011 Arutha

    LazyBot is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    LazyBot is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with LazyBot.  If not, see <http://www.gnu.org/licenses/>.
*/

#region

using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using LazyEvo.Forms.Helpers;
using LazyLib;
using LazyLib.Helpers;
using LazyLib.Manager;
using LazyLib.Wow;

#endregion

namespace LazyEvo.Forms
{
    internal partial class Selector : Office2007Form
    {
        private Process[] _wowProc = Process.GetProcesses().Where(t => t.ProcessName.Contains("Wow")).ToArray();
        public Selector()
        {
            InitializeComponent();
            Geometry.GeometryFromString(GeomertrySettings.ProcessSelector, this);
        }

        private void BtnAttach_Click(object sender, EventArgs e)
        {
            if (SelectProcess.SelectedItem != null)
            {
                if (SelectProcess.SelectedItem.ToString() != "No game")
                {
                    Program.AttachTo = _wowProc[SelectProcess.SelectedIndex].Id;
                }
                else
                {
                    Program.AttachTo = -1;
                }
                Close();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshProcess();
        }

        private void RefreshProcess()
        {
            SelectProcess.Items.Clear();
            _wowProc = Process.GetProcesses().Where(t => t.ProcessName.Contains("Wow")).ToArray();
            foreach (Process proc in _wowProc)
            {
                GetName(proc);
            }
            if (SelectProcess.Items.Count == 0)
                SelectProcess.Items.Add("No game");
            SelectProcess.SelectedIndex = 0;
        }

        private void GetName(Process proc)
        {
            var build = proc.MainModule.FileVersionInfo.FilePrivatePart;
            if (Memory.OpenProcess(proc.Id))
            {
                string name = "Not ingame";
                try
                {
                    var matchingTypes = typeof(IGamePointers).Assembly
                        .GetTypes()
                        .Where(type =>
                            typeof(IGamePointers).IsAssignableFrom(type) &&
                            type.GetCustomAttributes(typeof(GameVersionAttribute), true).Cast<GameVersionAttribute>().SingleOrDefault()?.Build == build);
                    if (matchingTypes?.Any() == true)
                    {
                        var pointerClass = (IGamePointers)Activator.CreateInstance(matchingTypes.SingleOrDefault());

                        if (Memory.Read<byte>(Memory.BaseAddress + (uint)pointerClass.InGame) == 1)
                        {
                            try
                            {
                                name = Memory.ReadUtf8(Memory.BaseAddress + (uint)pointerClass.PlayerName, 256);
                            }
                            catch
                            {
                            }
                        }
                    }
                    else
                    {
                        name = $"Unsupported client {build}";
                    }
                }
                catch
                {
                }
                SelectProcess.Items.Add("[" + proc.Id + "]" + " - " + name);
            }
        }

        private void Selector_Load(object sender, EventArgs e)
        {
            RefreshProcess();
        }

        private void Selector_FormClosing(object sender, FormClosingEventArgs e)
        {
            GeomertrySettings.ProcessSelector = Geometry.GeometryToString(this);
        }
    }
}
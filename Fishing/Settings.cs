﻿
﻿/*
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
using System;
using System.Windows.Forms;

namespace LFishingEngine
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            KeysLureBar.SelectedIndex = KeysLureBar.FindStringExact(FishingSettings.LureBar);
            KeysLureKey.SelectedIndex = KeysLureKey.FindStringExact(FishingSettings.LureKey);
            UseLure.Checked = FishingSettings.UseLure;
        }

        private void SaveSettings_Click(object sender, EventArgs e)
        {
            FishingSettings.LureBar = KeysLureBar.SelectedItem.ToString();
            FishingSettings.LureKey = KeysLureKey.SelectedItem.ToString();
            FishingSettings.UseLure = UseLure.Checked;
            FishingSettings.SaveSettings();
            Close();
        }
    }
}

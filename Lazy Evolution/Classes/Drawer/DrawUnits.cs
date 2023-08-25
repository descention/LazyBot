
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
using LazyLib.Wow;
using System.Drawing;
using System.Runtime.Remoting.Channels;
using Unity;

namespace LazyLib.LazyRadar.Drawer
{
    internal class DrawUnits : IDrawItem
    {
        private readonly Color _colorUnits = Color.BlueViolet;

        #region IDrawItem Members

        public void Draw(RadarForm form)
        {
            var _objectManager = ServiceManager.Provider.GetService<IObjectManager>();

            const string othTop = "";
            string othBot;
            foreach (PUnit mob in _objectManager.GetUnits)
            {
                if (mob.GUID.Equals(_objectManager.MyPlayer.GUID))
                    continue;

                if (mob.IsPlayer)
                    continue;

                if (mob.IsDead)
                    continue;

                othBot = mob.Name + " ";
                othBot = othBot.TrimEnd();

                form.PrintArrow(_colorUnits,
                                form.OffsetY(mob.Location.Y, _objectManager.MyPlayer.Location.Y),
                                form.OffsetX(mob.Location.X, _objectManager.MyPlayer.Location.X),
                                mob.Facing, othTop, othBot);
            }
        }

        public string SettingName()
        {
            return "DrawUnits";
        }

        public string CheckBoxName()
        {
            return "Show units";
        }

        #endregion
    }
}
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
using System.Drawing;
using System.Linq;
using LazyLib.Wow;

namespace LazyLib.LazyRadar.Drawer
{
    internal class DrawFriends : IDrawItem
    {
        private readonly Color _colorFriends = Color.Blue;

        #region IDrawItem Members

        public void Draw(RadarForm form)
        {
            string othBot;
            foreach (
                PPlayer<T> play in
                    ObjectManager<T>.GetPlayers.Where(cur => cur.PlayerFaction.Equals(ObjectManager<T>.MyPlayer.PlayerFaction))
                )
            {
                if (play.GUID.Equals(ObjectManager<T>.MyPlayer.GUID))
                    continue;
                string othTop = play.Name;
                othBot = " Lvl: " + play.Level;
                othBot = othBot.TrimEnd();
                form.PrintArrow(_colorFriends, form.OffsetY(play.Location.Y, ObjectManager<T>.MyPlayer.Location.Y),
                                form.OffsetX(play.Location.X, ObjectManager<T>.MyPlayer.Location.X),
                                play.Facing, othTop, othBot);
            }
        }

        public string SettingName()
        {
            return "DrawFriends";
        }

        public string CheckBoxName()
        {
            return "Show friends";
        }

        #endregion
    }
}
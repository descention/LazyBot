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

using LazyLib.IPlugin;

namespace LazyEvo.LGrindEngine.Helpers
{
    public class Converter : ILazyPlugin
    {
        #region ILazyPlugin Members

        public string GetName()
        {
            return "Profile Converter";
        }

        public void PluginLoad()
        {
        }

        public void PluginUnload()
        {
        }

        public void BotStart()
        {
        }

        public void BotStop()
        {
        }

        public void Pulse()
        {
        }

        public void Settings()
        {
            var form = new ConverterForm();
            form.Show();
        }

        #endregion
    }
}
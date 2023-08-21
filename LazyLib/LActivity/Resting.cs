
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
using System.Reflection;
using System.Threading;
using LazyLib.Helpers;
using LazyLib.Wow;

namespace LazyLib.LActivity
{
    [Obfuscation(Feature = "renaming", ApplyToMembers = true)]
    public class Resting
    {
        private static Boolean _regenHealth;
        private static Boolean _regenMana;
        private static readonly Ticker DrinkTimer = new Ticker(300*100);
        private static readonly Ticker EatTimer = new Ticker(300*100);
        private static bool _bIsDrinking;
        private static bool _bIsEating;

        public static Boolean NeedResting
        {
            get
            {
                bool need = false;
                _regenMana = false;
                _regenHealth = false;
                if (!ObjectManager<T>.MyPlayer.IsAlive)
                    return false;
                if (LazySettings.CombatBoolDrink && ObjectManager<T>.MyPlayer.PowerType.Equals("Mana") &&
                    ObjectManager<T>.MyPlayer.Mana < Convert.ToInt32(LazySettings.CombatDrinkAt))
                {
                    _regenMana = true;
                    need = true;
                }
                if (LazySettings.CombatBoolEat &&
                    ObjectManager<T>.MyPlayer.Health < Convert.ToInt32(LazySettings.CombatEatAt))
                {
                    _regenHealth = true;
                    need = true;
                }
                return need;
            }
        }

        public static void Rest()
        {
            while (ObjectManager<T>.MyPlayer.InCombat && !ObjectManager<T>.ShouldDefend)
                Thread.Sleep(1000);
            if (ObjectManager<T>.ShouldDefend)
                return;
            if (_regenHealth)
                EatSomething();
            if (_regenMana)
                DrinkSomething();
            if (_bIsDrinking || _bIsEating)
            {
                while (true)
                {
                    Thread.Sleep(101);
                    if (ObjectManager<T>.MyPlayer.IsDead || ObjectManager<T>.MyPlayer.IsGhost)
                        break;
                    if (ObjectManager<T>.GetAttackers.Count != 0)
                        break;
                    if (_bIsEating && !_bIsDrinking)
                        if (ObjectManager<T>.MyPlayer.Health == 100) break;
                    if (!_bIsEating && _bIsDrinking)
                        if (ObjectManager<T>.MyPlayer.Mana == 100) break;
                    if (EatTimer.IsReady && _bIsEating)
                        break;
                    if (DrinkTimer.IsReady && _bIsDrinking)
                    {
                        break;
                    }
                    if (ObjectManager<T>.MyPlayer.IsDead)
                        break;
                    if (ObjectManager<T>.MyPlayer.Health == 100 && ObjectManager<T>.MyPlayer.Mana == 100) break;
                }
            }
            Logging.Write("[Rest]We are not eating or drinking lets continue");
            _bIsEating = false;
            _bIsDrinking = false;
        }

        private static void EatSomething()
        {
            if (ObjectManager<T>.MyPlayer.IsDead) return;
            if (ObjectManager<T>.GetAttackers.Count == 0)
            {
                EatTimer.Reset();
                Logging.Write("[Rest]Eating");
                KeyHelper.SendKey("Eat");
                Thread.Sleep(300);
                _bIsEating = true;
            }
        }

        private static void DrinkSomething()
        {
            if (ObjectManager<T>.MyPlayer.IsDead) return;
            if (ObjectManager<T>.GetAttackers.Count == 0)
            {
                DrinkTimer.Reset();
                Logging.Write("[Rest]Drinking");
                KeyHelper.SendKey("Drink");
                Thread.Sleep(300);
                _bIsDrinking = true;
            }
        }
    }
}
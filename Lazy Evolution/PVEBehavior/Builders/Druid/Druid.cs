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

using System.Collections.Generic;
using LazyEvo.PVEBehavior.Behavior;
using LazyEvo.PVEBehavior.Behavior.Conditions;
using LazyLib.ActionBar;

namespace LazyEvo.PVEBehavior.Builders
{
    internal class Druid
    {
        public static List<AddToBehavior> Load()
        {
            var add = new List<AddToBehavior>();

            //----------- Pull actions 

            int spellId = 100; // Charge
            string spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Pull, Spec.Normal, new Rule(spell, new ActionSpell(spell), 1,
                                               new List<AbstractCondition>
                                                   {new DistanceToTarget(ConditionEnum.LessThan, 25)})));

            spellId = 57755; // Deadly Throw
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Pull, Spec.Normal,
                                      new Rule(spell, new ActionSpell(spell), 2,
                                               new List<AbstractCondition> 
                                               { new DistanceToTarget(ConditionEnum.MoreThan, 5), 
                                                 new DistanceToTarget(ConditionEnum.LessThan, 30)})));

            //{
            //    Log("Pull Successful on " + target.Name + ".");
            //    Thread.Sleep(250);
           // }

            //-----------  Combat Actions
            //  Healing
            spellId = 34428; // Victory Rush - ?
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 3,
                                                                               new List<AbstractCondition>
                                                                                   {
                                                                                       new BuffCondition(
                                                                                           ConditionTargetEnum.Player,
                                                                                           BuffConditionEnum.HasBuff,
                                                                                           BuffValueEnum.Id, "32216")
                                                                                   })));
            // Defensive Actions
            spellId = 97462; // Rallying Cry - buff when low hp
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 4,
                                                                               new List<AbstractCondition>
                                                                                   {
                                                                                       new HealthPowerCondition(
                                                                                           ConditionTargetEnum.Player,
                                                                                           ConditionTypeEnum.Health,
                                                                                           ConditionEnum.LessThan, 20),
                                                                                        new BuffCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            BuffConditionEnum.
                                                                                                DoesNotHave,
                                                                                            BuffValueEnum.Id, "97463")
                                                                                   })));

            spellId = 118038; // Die by the sword - buff when low hp
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 5,
                                                                               new List<AbstractCondition>
                                                                                   {
                                                                                       new HealthPowerCondition(
                                                                                           ConditionTargetEnum.Player,
                                                                                           ConditionTypeEnum.Health,
                                                                                           ConditionEnum.LessThan, 30),
                                                                                        new BuffCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            BuffConditionEnum.
                                                                                                DoesNotHave,
                                                                                            BuffValueEnum.Id, "118038")
                                                                                   })));

            spellId = 871; // Shield Wall
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 6,
                                                                               new List<AbstractCondition>
                                                                                   {
                                                                                       new HealthPowerCondition(
                                                                                           ConditionTargetEnum.Player,
                                                                                           ConditionTypeEnum.Health,
                                                                                           ConditionEnum.LessThan, 30),                                                                                        
                                                                                           new BuffCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            BuffConditionEnum.
                                                                                                DoesNotHave,
                                                                                            BuffValueEnum.Id, "871")
                                                                                   })));
            spellId = 5246; // Intimidating Shout ??
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 7,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new DistanceToTarget(
                                                                                            ConditionEnum.LessThan, 8),
                                                                                       /* new FunctionsCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            FunctionsConditionEnum.Not,
                                                                                            FunctionEnum.Feared),
                                                                                        */
                                                                                        new HealthPowerCondition(
                                                                                           ConditionTargetEnum.Player,
                                                                                           ConditionTypeEnum.Health,
                                                                                           ConditionEnum.LessThan, 30),
                                                                                     })));

            //Buffs to be used in combat
            spellId = 18499; // Berserker Rage
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Buff, Spec.Normal, new Rule(spell, new ActionSpell(spell), 8,
                                                                               new List<AbstractCondition>
                                                                                   {
                                                                                       new BuffCondition(
                                                                                           ConditionTargetEnum.Player,
                                                                                           BuffConditionEnum.DoesNotHave,
                                                                                           BuffValueEnum.Id, "18499"),
                                                                                   })));    

            // Offensive Actions
            spellId = 49028; // Recklessness 
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 9,
                                                                               new List<AbstractCondition>
                                                                                   {
                                                                                       new CombatCountCondition(
                                                                                           ConditionEnum.MoreThan, 2)
                                                                                   })));
            spellId = 114207; // Skull Banner
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 10,
                                                                               new List<AbstractCondition>
                                                                                   {
                                                                                       new CombatCountCondition(
                                                                                           ConditionEnum.MoreThan, 2),
                                                                                           new BuffCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            BuffConditionEnum.
                                                                                                DoesNotHave,
                                                                                            BuffValueEnum.Id, "114206")
                                                                                   })));
            spellId = 6552; // Pummel
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 11,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new FunctionsCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            FunctionsConditionEnum.Is,
                                                                                            FunctionEnum.Casting)
                                                                                    })));
            spellId = 23920; // Spell Reflection
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 12,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new FunctionsCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            FunctionsConditionEnum.Is,
                                                                                            FunctionEnum.Casting)
                                                                                    })));
            spellId = 845; // Cleave -aoe
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 13,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new CombatCountCondition(
                                                                                           ConditionEnum.MoreThan, 1),
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            ConditionTypeEnum.Rage,
                                                                                            ConditionEnum.MoreThan, 60)
                                                                                     })));
            spellId = 1680; // Whirlwind - arms+fury - aoe
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 14,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new CombatCountCondition(
                                                                                           ConditionEnum.MoreThan, 2),
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            ConditionTypeEnum.Rage,
                                                                                            ConditionEnum.MoreThan, 30)
                                                                                     })));
            spellId = 6343; // Thunder Clap - aoe
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 15,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new CombatCountCondition(
                                                                                           ConditionEnum.MoreThan, 1),
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            ConditionTypeEnum.Rage,
                                                                                            ConditionEnum.MoreThan, 20)
                                                                                     })));

            spellId = 86346; // Colossus smash
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 16,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            ConditionTypeEnum.Health,
                                                                                            ConditionEnum.MoreThan, 20)
                                                                                     })));
            spellId = 5308; // Execute
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 17,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            ConditionTypeEnum.Health,
                                                                                            ConditionEnum.LessThan, 20),
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            ConditionTypeEnum.Rage,
                                                                                            ConditionEnum.MoreThan, 30)
                                                                                     })));

            spellId = 78; // Heroic Strike
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 18,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            ConditionTypeEnum.Health,
                                                                                            ConditionEnum.MoreThan, 20),
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            ConditionTypeEnum.Rage,
                                                                                            ConditionEnum.MoreThan, 50)
                                                                                     })));

            // spells by specc - arms(spec.tree1) - fury (spec.tree2) - defensive (spec.tree3)

            spellId = 12294; // Mortal Strike - Arms specc
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Tree1, new Rule(spell, new ActionSpell(spell), 1,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            ConditionTypeEnum.Health,
                                                                                            ConditionEnum.MoreThan, 20)
                                                                                    })));
            spellId = 1464; // Slam - Arms specc - after colossus smash
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Tree1, new Rule(spell, new ActionSpell(spell), 2,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new BuffCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            BuffConditionEnum.HasBuff,
                                                                                            BuffValueEnum.Id, "86346"),
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            ConditionTypeEnum.Health,
                                                                                            ConditionEnum.MoreThan, 20),
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            ConditionTypeEnum.Rage,
                                                                                            ConditionEnum.MoreThan, 25)
                                                                                    })));
            spellId = 7384; // Overpower - Arms specc - Taste for blood buff
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Tree1, new Rule(spell, new ActionSpell(spell), 3,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new BuffCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            BuffConditionEnum.HasBuff,
                                                                                            BuffValueEnum.Id, "56636"),
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            ConditionTypeEnum.Health,
                                                                                            ConditionEnum.MoreThan, 20),
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            ConditionTypeEnum.Rage,
                                                                                            ConditionEnum.MoreThan, 10)
                                                                                    })));

            spellId = 23881; // Bloodthirst - Fury specc
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Tree2, new Rule(spell, new ActionSpell(spell), 1,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            ConditionTypeEnum.Health,
                                                                                            ConditionEnum.LessThan, 80),
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            ConditionTypeEnum.Rage,
                                                                                            ConditionEnum.MoreThan, 30)
                                                                                    })));

            spellId = 100130; // Wild Strike - Fury Specc
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Tree2, new Rule(spell, new ActionSpell(spell), 2,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            ConditionTypeEnum.Rage,
                                                                                            ConditionEnum.MoreThan, 30)
                                                                                    })));

            spellId = 85288; // Raging Blow - Fury Specc
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Tree2, new Rule(spell, new ActionSpell(spell), 3,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new BuffCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            BuffConditionEnum.HasBuff,
                                                                                            BuffValueEnum.Id, "18499"),
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            ConditionTypeEnum.Rage,
                                                                                            ConditionEnum.MoreThan, 30)
                                                                                    })));
            spellId = 20243; // Devastate - Protection Specc
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Tree3, new Rule(spell, new ActionSpell(spell), 1,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            ConditionTypeEnum.Health,
                                                                                            ConditionEnum.MoreThan, 20)
                                                                                    })));
            spellId = 23922; // Shield Slam - Protection Specc
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Tree3, new Rule(spell, new ActionSpell(spell), 2,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            ConditionTypeEnum.Health,
                                                                                            ConditionEnum.MoreThan, 20)
                                                                                    })));
            spellId = 6572; // Revenge - Protection Specc
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Tree3, new Rule(spell, new ActionSpell(spell), 3,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            ConditionTypeEnum.Health,
                                                                                            ConditionEnum.MoreThan, 20)
                                                                                    })));

            spellId = 2565; // Shield Block - Protection Specc
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Tree3, new Rule(spell, new ActionSpell(spell), 4,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            ConditionTypeEnum.Health,
                                                                                            ConditionEnum.LessThan, 60),
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            ConditionTypeEnum.Rage,
                                                                                            ConditionEnum.MoreThan, 60)
                                                                                    })));


            //----------- Talents


            spellId = 103840; // Impending victory-normal cast
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 1,
                                                                               new List<AbstractCondition>
                                                                                   {
                                                                                       new HealthPowerCondition(
                                                                                           ConditionTargetEnum.Player,
                                                                                           ConditionTypeEnum.Health,
                                                                                           ConditionEnum.LessThan, 70)
                                                                                   })));
            spellId = 55694; // Enraged Regeneration
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 2,
                                                                               new List<AbstractCondition>
                                                                                   {
                                                                                       new HealthPowerCondition(
                                                                                           ConditionTargetEnum.Player,
                                                                                           ConditionTypeEnum.Health,
                                                                                           ConditionEnum.LessThan, 70)
                                                                                   })));

            spellId = 102060; // Disrupting Shout - if Spell Reflection/Mass Spell Reflection is on cd
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 3,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new FunctionsCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            FunctionsConditionEnum.Is,
                                                                                            FunctionEnum.Casting),
                                                                                        new BuffCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            BuffConditionEnum.
                                                                                                DoesNotHave,
                                                                                            BuffValueEnum.Id, "23920"),
                                                                                        new BuffCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            BuffConditionEnum.
                                                                                                DoesNotHave,
                                                                                            BuffValueEnum.Id, "114028")
                                                                                    })));
            spellId = 118000; // Dragon Roar - cast on cd
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 4,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            ConditionTypeEnum.Health,
                                                                                            ConditionEnum.MoreThan, 20)
                                                                                    })));

            spellId = 46968; // Shockwave - ??
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 5,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new DistanceToTarget(
                                                                                            ConditionEnum.LessThan, 10),
                                                                                        /*new FunctionsCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            FunctionsConditionEnum.IsNot,
                                                                                            FunctionEnum.Stunned)*/
                                                                                     })));

            spellId = 46924; // Bladestorm
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 6,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                       new CombatCountCondition(
                                                                                           ConditionEnum.MoreThan, 1)
                                                                                     })));

            spellId = 114028; // Mass Spell Reflection - if player does not have Spell Reflection active
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 7,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new FunctionsCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            FunctionsConditionEnum.Is,
                                                                                            FunctionEnum.Casting),
                                                                                        new BuffCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            BuffConditionEnum.
                                                                                                DoesNotHave,
                                                                                            BuffValueEnum.Id, "23920")
                                                                                    })));

            spellId = 107570; // Stormbolt - stun-??
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 8,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new DistanceToTarget(
                                                                                            ConditionEnum.LessThan, 30),
                                                                                        /*new FunctionsCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            FunctionsConditionEnum.IsNot,
                                                                                            FunctionEnum.Stunned),*/
                                                                                     })));
            spellId = 12292; // Bloodbath
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 9,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            ConditionTypeEnum.Health,
                                                                                            ConditionEnum.MoreThan, 50)
                                                                                     })));

            spellId = 107574; // Avatar
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Combat, Spec.Normal, new Rule(spell, new ActionSpell(spell), 10,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new HealthPowerCondition(
                                                                                            ConditionTargetEnum.Target,
                                                                                            ConditionTypeEnum.Health,
                                                                                            ConditionEnum.MoreThan, 50)
                                                                                     })));

            //----------- Stances - Spec.special1

            spellId = 768; // Cat Form
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Buff, Spec.Special, new Rule(spell, new ActionSpell(spell), 1,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new BuffCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            BuffConditionEnum.
                                                                                                DoesNotHave,
                                                                                            BuffValueEnum.Name,
                                                                                            "Cat Form")
                                                                                    })));
            spellId = 33891; // Incarnation: Tree of Life	
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Buff, Spec.Special, new Rule(spell, new ActionSpell(spell), 2,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new BuffCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            BuffConditionEnum.
                                                                                                DoesNotHave,
                                                                                            BuffValueEnum.Name,
                                                                                            "Tree of Life")
                                                                                    })));

            spellId = 5487; // Bear Form
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Buff, Spec.Special, new Rule(spell, new ActionSpell(spell), 3,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new BuffCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            BuffConditionEnum.
                                                                                                DoesNotHave,
                                                                                            BuffValueEnum.Name,
                                                                                            "Bear Form")
                                                                                    })));
            spellId = 24858; // Moonkin Form
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Buff, Spec.Special, new Rule(spell, new ActionSpell(spell), 3,
                                                                                new List<AbstractCondition>
                                                                                    {
                                                                                        new BuffCondition(
                                                                                            ConditionTargetEnum.Player,
                                                                                            BuffConditionEnum.
                                                                                                DoesNotHave,
                                                                                            BuffValueEnum.Name,
                                                                                            "Moonkin Form")
                                                                                    })));


            //-----------  Buff Actions
            spellId = 6673; // Battle Shout
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Buff, Spec.Special2, new Rule(spell, new ActionSpell(spell), 1,
                                                                               new List<AbstractCondition>
                                                                                   {
                                                                                       new BuffCondition(
                                                                                           ConditionTargetEnum.Player,
                                                                                           BuffConditionEnum.DoesNotHave,
                                                                                           BuffValueEnum.Id, "6673"),
                                                                                   })));
            spellId = 469; // Commanding Shout
            spell = BarMapper.GetNameFromSpell(spellId);
            add.Add(new AddToBehavior(spell, Type.Buff, Spec.Special2, new Rule(spell, new ActionSpell(spell), 2,
                                                                               new List<AbstractCondition>
                                                                                   {
                                                                                       new BuffCondition(
                                                                                           ConditionTargetEnum.Player,
                                                                                           BuffConditionEnum.DoesNotHave,
                                                                                           BuffValueEnum.Id, "469"),
                                                                                   })));

            return add;
        }
    }
}
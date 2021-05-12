using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wizardry_Assistant.Models
{
    public class AttackSpell : Spell
    {
        public uint MinDamage { get; set; }
        public uint MaxDamage { get; set; }
        public bool XCost { get; set; }

        public override string ToString()
        {
            return Name;
        }
        
        public SpellResult CalculateDamage(float enemyHealth, float baseBoost, List<float> debuffs,
            List<CharmSpell> charmSpells)
        {
            if (!XCost) {
                float totalDamage = MinDamage;
                totalDamage *= baseBoost;
                foreach (var debuff in debuffs) {
                    totalDamage *= debuff;
                }
                var totalCost = (int) Cost;
                var spellsRequired = new List<CharmSpell>();
                var validSpellsQuery =
                    from charmSpell in charmSpells
                    where charmSpell.School == School
                        orderby charmSpell.Cost, charmSpell.Amount descending 
                            select charmSpell;
                foreach (var charmSpell in validSpellsQuery) {
                    totalDamage *= charmSpell.Amount;
                    totalCost += (int) charmSpell.Cost;
                    spellsRequired.Add(charmSpell);
                    if (totalDamage >= enemyHealth) {
                        break;
                    }
                }
                return new SpellResult(totalDamage, totalCost, spellsRequired, this);
            }
            else {
                float damage = MinDamage;
                var spellsRequired = new List<CharmSpell>();
                var validSpellsQuery =
                    from charmSpell in charmSpells
                    where charmSpell.School == School
                        orderby charmSpell.Cost, charmSpell.Amount descending
                            select charmSpell;
                var currentPips = 1;
                var multiplier = baseBoost;
                multiplier = debuffs.Aggregate(multiplier, (f, f1) => f * f1);
                damage *= multiplier;
                var charmsEnum = validSpellsQuery.GetEnumerator();
                while (damage < enemyHealth) {
                    currentPips++;
                    if (!charmsEnum.MoveNext()) {
                        damage = currentPips * MinDamage * multiplier;
                        continue;
                    }
                    var nextCharm = charmsEnum.Current;
                    if (damage * nextCharm.Amount < MinDamage * multiplier * (currentPips + nextCharm.Cost) 
                        || nextCharm.Cost > currentPips) {
                        continue;
                    }
                    currentPips -= (int) nextCharm.Cost;
                    spellsRequired.Add(nextCharm);
                    multiplier *= nextCharm.Amount;
                    damage = currentPips * MinDamage * multiplier;
                }
                charmsEnum.Dispose();
                return new SpellResult(damage * currentPips * multiplier, currentPips, spellsRequired, this);
            }
        }
        
        public struct SpellResult
        {
            public float Damage { get; set; }
            public int PipsRequired { get; set; }
            public List<CharmSpell> CharmsRequired { get; set; }
            
            public AttackSpell Attack { get; set; }

            public SpellResult(float damage, int pipsRequired, List<CharmSpell> charmsRequired, AttackSpell attack)
            {
                Damage = damage;
                PipsRequired = pipsRequired;
                CharmsRequired = charmsRequired;
                Attack = attack;
            }
        }
    }
}

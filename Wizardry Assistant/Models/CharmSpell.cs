using System;
using System.Collections.Generic;
using System.Text;

namespace Wizardry_Assistant.Models
{
    public class CharmSpell : Spell
    {
        public enum CharmTypes
        {
            Blade,
            Trap,
            Aura,
            Field,
            Flat
        }
        
        public float Amount { get; set; }

        public override string ToString()
        {
            var amt = Amount - 1;
            amt *= 100;
            return $"{Name} +{(int) amt}%";
        }
    }
}

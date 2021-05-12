using System;
using System.Collections.Generic;
using System.Text;

namespace Wizardry_Assistant.Models
{
    public abstract class Spell
    {
        public enum Schools
        {
            Storm,
            Fire,
            Ice,
            Balance,
            Life,
            Death,
            Myth
        }

        public uint Cost { get; set; }
        public Schools School { get; set; }
        public string Name { get; set; }

        public void SetSchool(string school)
        {
            School = Enum.Parse<Schools>(school);
        }
    }
}

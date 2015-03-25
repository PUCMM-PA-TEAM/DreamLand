using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamLand.Scripts.classes {
    abstract class Character
    {
        public String Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Magic { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int Level { get; set; }
        public int Damage { get; set; }


    }
}

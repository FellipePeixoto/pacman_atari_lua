using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pacman_atari
{
    class GlobalEnums
    {
        public enum Direction
        {
            up, right, down, left, stopped
        }

        public enum ObjectType 
        { 
            alive, dot, pill, fruit, block, none, ghost
        }
    }
}

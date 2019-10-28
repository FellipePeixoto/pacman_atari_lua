using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman_Atari
{
    class Enum
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

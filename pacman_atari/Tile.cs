#region using
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace pacman_atari
{
    class Tile : ObjectStatic
    {
        public Tile(Vector2 position, Vector2 scale, String textureName, Color color) 
        {
            this.position = position;
            this.scale = scale;
            this.textureName = textureName;
            this.color = color;

            this.type = GlobalEnums.ObjectType.block;
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)scale.X, (int)scale.Y);
        }
    }
}

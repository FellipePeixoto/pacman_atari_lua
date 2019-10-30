﻿#region using
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
    class Dot:ObjectStatic
    {
        public Dot(Vector2 position, String textureName, Color color)
        {
            this.position = position;
            this.textureName = textureName;
            this.color = color;

            type = GlobalEnums.ObjectType.dot;
            this.scale = new Vector2(8, 2);
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)scale.X, (int)scale.Y);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using pacman_atari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacman_atari
{
    class Moveable : Object
    {
        protected int directionSelected = -1;
        protected Vector2 newPos;
        protected GlobalEnums.Direction actualDirection;
        protected readonly int distance = 1;
        protected int size = 15;
        protected Rectangle collider;
        protected SpriteEffects spriteEffects;

        public void Move()
        {
            switch (directionSelected)
            {
                case 0:
                    if (!CheckCollision(new Rectangle((int)newPos.X - distance, (int)newPos.Y, distance, size)))
                        actualDirection = GlobalEnums.Direction.left;
                    break;
                case 1:
                    if (!CheckCollision(new Rectangle((int)newPos.X, (int)newPos.Y - distance, size, distance)))
                        actualDirection = GlobalEnums.Direction.up;
                    break;
                case 2:
                    if (!CheckCollision(new Rectangle((int)newPos.X + distance + size, (int)newPos.Y, distance, size)))
                        actualDirection = GlobalEnums.Direction.right;
                    break;
                case 3:
                    if (!CheckCollision(new Rectangle((int)newPos.X, (int)newPos.Y + distance + size, size, distance)))
                        actualDirection = GlobalEnums.Direction.down;
                    break;
            }

            switch (actualDirection)
            {
                case GlobalEnums.Direction.up:
                    if (!CheckCollision(new Rectangle((int)newPos.X, (int)newPos.Y - distance, size, distance)))
                        position.Y -= speed;
                    break;

                case GlobalEnums.Direction.right:
                    if (!CheckCollision(new Rectangle((int)newPos.X + distance + size, (int)newPos.Y, distance, size)))
                    {
                        spriteEffects = SpriteEffects.None;
                        position.X += speed;
                    }
                    break;

                case GlobalEnums.Direction.down:
                    if (!CheckCollision(new Rectangle((int)newPos.X, (int)newPos.Y + distance + size, size, distance)))
                        position.Y += speed;
                    break;

                case GlobalEnums.Direction.left:
                    if (!CheckCollision(new Rectangle((int)newPos.X - distance, (int)newPos.Y, distance, size)))
                    {
                        spriteEffects = SpriteEffects.FlipHorizontally;
                        position.X -= speed;
                    }
                    break;
            }
        }

        /// <summary>
        /// Checa a colisão contra objeto solido
        /// </summary>
        /// <returns></returns>
        protected bool CheckCollision(Rectangle rectangle)
        {
            foreach (ObjectStatic i in Items.objMovList)
            {
                if (i != null && rectangle.Intersects(i.rectangle) &&
                    (i.type == GlobalEnums.ObjectType.block || i.type == GlobalEnums.ObjectType.ghost))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checar colisão contra objeto especifico
        /// </summary>
        /// <param name="type">Enumerador dos tipos de entidades no mapa</param>
        /// <returns>Verdadeiro caso o há colisão</returns>
        protected bool CheckCollision(GlobalEnums.ObjectType type, bool destroy)
        {
            foreach (ObjectStatic i in Items.objMovList)
            {
                if (i != null && collider.Intersects(i.rectangle) &&
                    (i.type == type))
                {
                    if (destroy)
                        Items.objMovList[Items.objMovList.IndexOf(i)] = null;
                    return true;
                }
            }
            return false;
        }

        public void Left()
        {
            directionSelected = 0;
        }

        public void Up()
        {
            directionSelected = 1;
        }

        public void Right()
        {
            directionSelected = 2;
        }

        public void Down()
        {
            directionSelected = 3;
        }
    }
}

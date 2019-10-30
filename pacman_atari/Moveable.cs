using Microsoft.Xna.Framework;
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
        protected GlobalEnums.Direction dir;
        protected GlobalEnums.Direction nextDir;
        protected int distance = 1;
        protected int size = 15;
        protected Rectangle collider;

        public void Move()
        {
            if (directionSelected == 1)
            {
                colliderDetection = new Rectangle((int)newPos.X, (int)newPos.Y - distance, size, distance);
                if (!CheckCollision())
                    dir = GlobalEnums.Direction.up;
                else
                    nextDir = GlobalEnums.Direction.up;
            }
            else if (directionSelected == 3)
            {
                colliderDetection = new Rectangle((int)newPos.X, (int)newPos.Y + distance + size, size, distance);
                if (!CheckCollision())
                    dir = GlobalEnums.Direction.down;
                else
                    nextDir = GlobalEnums.Direction.down;
            }
            else if (directionSelected == 2)
            {
                colliderDetection = new Rectangle((int)newPos.X + distance + size, (int)newPos.Y, distance, size);
                if (!CheckCollision())
                    dir = GlobalEnums.Direction.right;
                else
                    nextDir = GlobalEnums.Direction.right;
            }
            else if (directionSelected == 0)
            {
                colliderDetection = new Rectangle((int)newPos.X - distance, (int)newPos.Y, distance, size);
                if (!CheckCollision())
                    dir = GlobalEnums.Direction.left;
                else
                    nextDir = GlobalEnums.Direction.left;
            }

            switch (dir)
            {
                case GlobalEnums.Direction.up:
                    colliderDetection = new Rectangle((int)newPos.X, (int)newPos.Y - distance, size, distance);
                    if (!CheckCollision())
                        position.Y -= speed;
                    break;

                case GlobalEnums.Direction.right:
                    colliderDetection = new Rectangle((int)newPos.X + distance + size, (int)newPos.Y, distance, size);
                    if (!CheckCollision())
                        position.X += speed;
                    break;

                case GlobalEnums.Direction.down:
                    colliderDetection = new Rectangle((int)newPos.X, (int)newPos.Y + distance + size, size, distance);
                    if (!CheckCollision())
                        position.Y += speed;
                    break;

                case GlobalEnums.Direction.left:
                    colliderDetection = new Rectangle((int)newPos.X - distance, (int)newPos.Y, distance, size);
                    if (!CheckCollision())
                        position.X -= speed;
                    break;
            }
        }

        /// <summary>
        /// Checa a colisão contra objeto solido
        /// </summary>
        /// <returns></returns>
        protected bool CheckCollision()
        {
            foreach (ObjectStatic i in Items.objMovList)
            {
                if (i != null && colliderDetection.Intersects(i.rectangle) &&
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

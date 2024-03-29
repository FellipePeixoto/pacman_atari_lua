﻿#region using
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NLua;
#endregion


namespace pacman_atari
{
    public enum sensor_states
    {
        enemy,free,wall
    }

    class Pacman : Moveable
    {
        private KeyboardState currentKeyBoardState;
        /// <summary>
        /// LEFT = 0
        /// UP = 1
        /// RIGHT = 2
        /// DOWN = 3
        /// </summary>
        private Animation walkAnimation;
        
        private Vector2 diff = new Vector2(15, 15);
        public static int score = 0;

        //Implementar os sensores por distancia
        sensor_states leftSensor;
        sensor_states topSensor;
        sensor_states rightSensor;
        sensor_states bottomSensor;

        public Pacman(Vector2 position, float speed, String textureName, String debugTextureName)
        {
            this.position = position;
            this.speed = speed;
            this.scale = 1;
            this.textureName = textureName;
            this.debugTextureName = debugTextureName;

            this.isAlive = true;

            actualDirection = GlobalEnums.Direction.stopped;

            walkAnimation = new Animation();

            spriteEffects = SpriteEffects.None;

            score = 0;
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            walkAnimation.Inatialize(texture, position, 14, 14, 4, 200, Color.White, scale, true, 0);

            center = new Vector2(walkAnimation.frameWidth / 2, walkAnimation.frameHeight / 2);
        }

        public override void Update(GameTime gameTime)
        {
            if (!isAlive)
                return;

            currentKeyBoardState = Keyboard.GetState();

            newPos = position - diff;

            if (currentKeyBoardState.IsKeyDown(Keys.Up))
            {
                directionSelected = 1;
            }
            else if (currentKeyBoardState.IsKeyDown(Keys.Down))
            {
                directionSelected = 3;
            }
            else if (currentKeyBoardState.IsKeyDown(Keys.Right))
            {
                directionSelected = 2;
            }
            else if (currentKeyBoardState.IsKeyDown(Keys.Left))
            {
                directionSelected = 0;
            }

            Move();

            if (position.Y < 0)
                position = new Vector2(((int)Game1.screenWidth / 2) + 7, (int)Game1.screenHeight - 20);

            if (position.Y > Game1.screenHeight - 20)
                position = new Vector2(((int)Game1.screenWidth / 2) + 7, 0);

            walkAnimation.position = position;
            walkAnimation.Update(gameTime);

            collider = new Rectangle((int)newPos.X + 4, (int)newPos.Y + 4, 7, 7);

            if (CheckCollision(GlobalEnums.ObjectType.dot, true))
                score++;
            if (CheckCollision(GlobalEnums.ObjectType.pill, true))
                score += 5;

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                walkAnimation.Draw(spriteBatch, center, true, spriteEffects);
            }
        }

        public Vector2 GetRandomCollect()
        {
            ObjectStatic selected = Items.dotsAndPills[new Random().Next(0, Items.dotsAndPills.Count)];

            if (selected != null)
                return selected.position;

            return new Vector2(-1, -1);
        }
    }
}

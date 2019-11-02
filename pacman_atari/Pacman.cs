#region using
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

            dir = GlobalEnums.Direction.stopped;

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

            #region movement
            if (currentKeyBoardState.IsKeyDown(Keys.Up))
            {
                colliderDetection = new Rectangle((int)newPos.X, (int)newPos.Y - distance, size, distance);
                if (!CheckCollision())
                    dir = GlobalEnums.Direction.up;
            }
            else if (currentKeyBoardState.IsKeyDown(Keys.Down))
            {
                colliderDetection = new Rectangle((int)newPos.X, (int)newPos.Y + distance + size, size, distance);
                if (!CheckCollision())
                    dir = GlobalEnums.Direction.down;
            }
            else if (currentKeyBoardState.IsKeyDown(Keys.Right))
            {
                colliderDetection = new Rectangle((int)newPos.X + distance + size, (int)newPos.Y, distance, size);
                if (!CheckCollision())
                    dir = GlobalEnums.Direction.right;
            }
            else if (currentKeyBoardState.IsKeyDown(Keys.Left))
            {
                colliderDetection = new Rectangle((int)newPos.X - distance, (int)newPos.Y, distance, size);
                if (!CheckCollision())
                    dir = GlobalEnums.Direction.left;
            }
            #endregion

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
    }
}

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
    class Items
    {
        #region Objetos moveis no cenario
        public static List<Object> objList = new List<Object>();

        public static Pacman pacman;

        public static Ghost ghostGreen;

        public static Ghost ghostLemonade;

        public static Ghost ghostWhiteGreen;

        public static Ghost ghostYellow;
        #endregion

        #region Objetos estaticos no cenario
        public static List<ObjectStatic> objMovList = new List<ObjectStatic>();
        #endregion

        #region Initialize
        public static void Initialize()
        {
            #region MapMatrix
            int[,] map = new int[41, 40]
            {
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                {1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,0,0,1,1,0,0,2,0,0,0,2,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                {1,1,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                {1,1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1,1,1},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                {1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,0,0,1,1,0,0,2,0,0,0,2,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                {1,1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1,1,1},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,1,1,5,0},
                {1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0},
                {1,1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1,1,1},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0},
                {1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                {1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,0,0,1,1,0,0,2,0,0,0,2,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                {1,1,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                {1,1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1,1,1},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0}
                
            };
            #endregion

            #region Map Initialize
            int blockSize = 4;
            int mapSize = Game1.screenWidth - 4;
            int dotOffSet = 3;
            int pillOffSet = 2;
            Vector2 trueStart = new Vector2(15, 15);
            Vector2 startPosPacman = Vector2.Zero;
            Vector2 startPosGhost = Vector2.Zero;

            #region Objetos estaticos (laco repeticao)
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 41; j++)
                {
                    switch (map[j, i])
                    {
                        case 1:
                            objMovList.Add(
                                new Tile(
                                    new Vector2(i * blockSize, j * blockSize),
                                    new Vector2(blockSize, blockSize),
                                    "block_tile",
                                    Color.White));
                            objMovList.Add(
                                new Tile(new Vector2((mapSize) - (i * blockSize), j * blockSize),
                                    new Vector2(blockSize, blockSize),
                                    "block_tile",
                                    Color.White));
                            break;
                        case 2:
                            objMovList.Add(
                                new Dot(
                                    new Vector2(i * blockSize, (j * blockSize) + dotOffSet),
                                    "block_tile",
                                    Color.White));
                            objMovList.Add(
                                new Dot(
                                    new Vector2((mapSize) - (i * blockSize), (j * blockSize) + dotOffSet),
                                    "block_tile",
                                    Color.White));
                            break;

                        case 3:
                            objMovList.Add(
                                new Pill(
                                    new Vector2(i * blockSize, (j * blockSize) + pillOffSet),
                                    "pill_tile",
                                    Color.White));
                            objMovList.Add(
                                new Pill(
                                    new Vector2((mapSize) - (i * blockSize) - blockSize, (j * blockSize) + pillOffSet),
                                    "pill_tile",
                                    Color.White));
                            break;

                        case 4:
                            startPosPacman = new Vector2(i * blockSize, j * blockSize);
                            break;

                        case 5:
                            startPosGhost = new Vector2((i * blockSize) + 1, (j * blockSize) + 1);
                            break;

                        default:
                            break;
                    }
                }
            }
            #endregion
            #endregion

            #region Objetos Moveis
            startPosPacman += trueStart;
            startPosGhost += trueStart;
            pacman = new Pacman(startPosPacman, 1, "pacman_animation", "debug");
            ghostGreen = new Ghost(startPosGhost, 1, "ghost_green_animation");
            Game1.instance.ghostsPursuing++;
            ghostLemonade = new Ghost(startPosGhost, 1, "ghost_lemonade_animation");
            Game1.instance.ghostsPursuing++;
            ghostWhiteGreen = new Ghost(startPosGhost, 1, "ghost_white-green_animation");
            Game1.instance.ghostsPursuing++;
            ghostYellow = new Ghost(startPosGhost, 1, "ghost_yellow_animation");
            Game1.instance.ghostsPursuing++;
            objList.Add(pacman);
            objList.Add(ghostGreen);
            objList.Add(ghostLemonade);
            objList.Add(ghostWhiteGreen);
            objList.Add(ghostYellow);
            #endregion
        }
        #endregion
    }
}

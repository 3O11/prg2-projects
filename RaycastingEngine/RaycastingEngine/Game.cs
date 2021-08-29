using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Input;

namespace RaycastingEngine {
    class Game {
        public Game() {
            _FOV = Math.PI / 2;
        }

        public static Game Load(string filename) {
            StreamReader file = new StreamReader(filename);

            // I'm relying on the correctness of the format
            var dims = Utils.ParseDimensions(file.ReadLine());
            MapTile[,] tiles = new MapTile[dims.Item1, dims.Item2];
            Vec2 playerPos = new Vec2(0, 0);

            string nextLine;
            int currentLine = 0;
            while ((nextLine = file.ReadLine()) != null) {
                for (int i = 0; i < nextLine.Length; ++i) {
                    switch (nextLine[i]) {
                        case '#':
                            tiles[i, currentLine] = MapTile.Wall;
                            break;
                        case 'P':
                            tiles[i, currentLine] = MapTile.Empty;
                            playerPos = new Vec2(i, currentLine);
                            break;
                        default:
                            tiles[i, currentLine] = MapTile.Empty;
                            break;
                    }
                }
                ++currentLine;
            }

            Game newGame = new Game();
            newGame._player = new Player(playerPos, new Vec2(0, -1));
            newGame._map = new Map(tiles, dims.Item1, dims.Item2);
            return newGame;
        } 

        public void Update() {
            // move player according to keys pressed
            // rotate player based on horizontal mouse movement
        }

        public void Render(Graphics g, int width, int height) {
            g.Clear(_skyColor);
            
            using (Brush ground = new SolidBrush(_groundColor)) {
                Rectangle lower = new Rectangle(0, height / 2, width, height / 2);
                g.FillRectangle(ground, lower);
            }

            for (int i = 0; i < width; ++i) {
                double multiplier = (width - 1 - i) / (width - 1);
                double offset = _FOV / 2;
                double currentAngle = (multiplier * _FOV) - offset;

                Vec2 rayDirection = new Vec2(_player.Direction);
                rayDirection.Rotate(currentAngle);

                double distance = _map.CastRay(_player.Position, rayDirection);
                //distance *= Math.Cos(Vec2.Angle(rayDirection, _player.Direction)); // Fish eye correction
                //distance /= Math.Sqrt(width * width + height * height); // Converting the distance into [0,1] interval for easier use

                double wallLength = (int)(height * (1 - distance));

                using (Pen wall = new Pen(_wallColor)) {
                    g.DrawLine(wall, i, (float)((height - wallLength) / 2), i, (float)(height - (height - wallLength) / 2));
                }
            }
        }

        Player _player;
        Map _map;

        double _FOV;

        Color _wallColor = Color.OrangeRed;
        Color _groundColor = Color.Brown;
        Color _skyColor = Color.LightBlue;
    }
}

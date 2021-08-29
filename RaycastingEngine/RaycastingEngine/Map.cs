using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaycastingEngine {

    enum MapTile {
        Empty,
        Wall,
    }

    class Map {
        public Map(MapTile[,] map, int width, int height) {
            _map = map;
            Width = width;
            Height = height;
        }

        public double CastRay(Vec2 position, Vec2 direction) {
            // Prepare all necessary variables
            int mapPosX = (int)position.x;
            int mapPosY = (int)position.y;

            double borderDistX = 0;
            double borderDistY = 0;

            double deltaDistX = Math.Sqrt(1 + (direction.y * direction.y) / (direction.x * direction.x));
            double deltaDistY = Math.Sqrt(1 + (direction.x * direction.x) / (direction.y * direction.y));
            double perpWallDist;

            int stepX = 0;
            int stepY = 0;

            int hit = 0;
            int side = 0;

            // Evaluate stepping and calculate initial tile border distances
            if (direction.x < 0) {
                stepX = -1;
                borderDistX = (position.x - mapPosX) * deltaDistX;
            }
            else {
                stepX = 1;
                borderDistX = (mapPosX + 1 - position.x) * deltaDistX;
            }

            if (direction.y < 0) {
                stepY = -1;
                borderDistY = (position.y - mapPosY) * deltaDistY;
            }
            else {
                stepY = 1;
                borderDistY = (mapPosY + 1 - position.y) * deltaDistY;
            }

            // Step the ray over the tiles and keep the distance
            while (hit == 0) {
                if (borderDistX < borderDistY) {
                    borderDistX += deltaDistX;
                    mapPosX += stepX;
                    side = 0;
                }
                else {
                    borderDistY += deltaDistY;
                    mapPosY += stepY;
                    side = 1;
                }

                if (_map[mapPosX, mapPosY] == MapTile.Wall) hit = 1;
            }

            // Depending on which side the ray collided with a wall, calculate the final collision distance
            if (side == 0) {
                perpWallDist = Math.Abs(mapPosX - position.x + (1 - stepX) / 2) / direction.x;
            }
            else {
                perpWallDist = Math.Abs(mapPosY - position.y + (1 - stepY) / 2) / direction.y;
            }

            return perpWallDist;
        }

        public bool CheckCollision(Vec2 pos) {
            return false;
        }

        MapTile[,] _map;
        public int Width { get; private set; }
        public int Height { get; private set; }
    }
}

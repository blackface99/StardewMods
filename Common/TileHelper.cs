using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewValley;
using xTile.Layers;

namespace Pathoschild.Stardew.Common
{
    /// <summary>Provides extension methods for working with tiles.</summary>
    internal static class TileHelper
    {
        /*********
        ** Public methods
        *********/
        /****
        ** Location
        ****/
        /// <summary>Get the tile coordinates in the game location.</summary>
        /// <param name="location">The game location to search.</param>
        public static IEnumerable<Vector2> GetTiles(this GameLocation location)
        {
            Layer layer = location.Map.Layers[0];
            return TileHelper.GetTiles(0, 0, layer.LayerWidth, layer.LayerHeight);
        }

        /****
        ** Rectangle
        ****/
        /// <summary>Get the tile coordinates in the tile area.</summary>
        /// <param name="area">The tile area to search.</param>
        public static IEnumerable<Vector2> GetTiles(this Rectangle area)
        {
            return TileHelper.GetTiles(area.X, area.Y, area.Width, area.Height);
        }

        /// <summary>Expand a rectangle equally in all directions.</summary>
        /// <param name="area">The rectangle to expand.</param>
        /// <param name="distance">The number of tiles to add in each direction.</param>
        public static Rectangle Expand(this Rectangle area, int distance)
        {
            return new Rectangle(area.X - distance, area.Y - distance, area.Width + distance * 2, area.Height + distance * 2);
        }

        /****
        ** Tiles
        ****/
        /// <summary>Get the eight tiles surrounding the given tile.</summary>
        /// <param name="tile">The center tile.</param>
        public static IEnumerable<Vector2> GetSurroundingTiles(this Vector2 tile)
        {
            return Utility.getSurroundingTileLocationsArray(tile);
        }

        /// <summary>Get the four tiles adjacent to the given tile.</summary>
        /// <param name="tile">The center tile.</param>
        public static IEnumerable<Vector2> GetAdjacentTiles(this Vector2 tile)
        {
            return Utility.getAdjacentTileLocationsArray(tile);
        }

        /// <summary>Get a rectangular grid of tiles.</summary>
        /// <param name="x">The X coordinate of the top-left tile.</param>
        /// <param name="y">The Y coordinate of the top-left tile.</param>
        /// <param name="width">The grid width.</param>
        /// <param name="height">The grid height.</param>
        public static IEnumerable<Vector2> GetTiles(int x, int y, int width, int height)
        {
            for (int curX = x, maxX = x + width - 1; curX <= maxX; curX++)
            {
                for (int curY = y, maxY = y + height - 1; curY <= maxY; curY++)
                    yield return new Vector2(curX, curY);
            }
        }

        /****
        ** Cursor
        ****/
        /// <summary>Get the tile under the player's cursor (not restricted to the player's grab tile range).</summary>
        public static Vector2 GetTileFromCursor()
        {
            return TileHelper.GetTileFromScreenPosition(Game1.getMouseX(), Game1.getMouseY());
        }

        /// <summary>Get the tile at the pixel coordinate relative to the top-left corner of the screen.</summary>
        /// <param name="x">The pixel X coordinate.</param>
        /// <param name="y">The pixel Y coordinate.</param>
        public static Vector2 GetTileFromScreenPosition(float x, float y)
        {
            return new Vector2((int)((Game1.viewport.X + x) / Game1.tileSize), (int)((Game1.viewport.Y + y) / Game1.tileSize));
        }
    }
}

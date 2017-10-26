using System;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewValley;

namespace Pathoschild.Stardew.TractorMod.Framework
{
    internal class TractorContentLoader : IAssetEditor, IAssetLoader
    {
        public bool CanEdit<T>(IAssetInfo asset)
        {
            return asset.AssetNameEquals(@"Data\Monsters");
        }

        public void Edit<T>(IAssetData asset)
        {
            asset
                .AsDictionary<string, string>()
                .Set("TractorStatic", "45/5/0/0/false/1000/390 .9 80 .1 382 .1 380 .1 96 .005 99 .001/5/.01/3/2/.00/true/5/Tractor");

        }

        /// <summary>Get whether this instance can load the initial version of the given asset.</summary>
        /// <param name="asset">Basic metadata about the asset being loaded.</param>
        public bool CanLoad<T>(IAssetInfo asset)
        {
            return asset.AssetNameEquals(@"Characters\Monsters\TractorStatic");
        }

        /// <summary>Load a matched asset.</summary>
        /// <param name="asset">Basic metadata about the asset being loaded.</param>
        public T Load<T>(IAssetInfo asset)
        {
            if (typeof(T) != typeof(Texture2D))
                throw new InvalidOperationException($"Can't load tractor sprite as type {typeof(T)}, must be {typeof(Texture2D)}.");

            return (T)(object)new Texture2D(Game1.graphics.GraphicsDevice, 1, 1); // this is just to prevent an error, the tractor will override it.
        }
    }
}

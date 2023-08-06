using System;
using System.Collections.Generic;
using System.Windows;
using BigReactorSimulator.Tiles;
using BigReactorSimulator.Views.Tiles;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.Reactor
{
    public class BigReactorViewModel : BaseViewModel
    {
        private readonly Action ClearRowsCallback;
        private readonly Action ClearColumnsCallback;
        private readonly Action<TileViewModel, int, int> AddTileCallback;
        private readonly Action<TileViewModel, int, int> RemoveTileCallback;
        private readonly Action ClearTilesCallback;

        public Dictionary<int, TileViewModel> SurfaceTiles;

        public delegate void TileChangedEventArgs(TileType oldTile, TileType newTile);
        public event TileChangedEventArgs OnTileChangedEvent;

        public BigReactorViewModel(
            Action clearRows, 
            Action clearColumns,
            Action<TileViewModel, int, int> addTile,
            Action<TileViewModel, int, int> removeTile,
            Action clearTiles)
        {
            this.ClearRowsCallback = clearRows;
            this.ClearColumnsCallback = clearColumns;
            this.AddTileCallback = addTile;
            this.RemoveTileCallback = removeTile;
            this.ClearTilesCallback = clearTiles;

            SurfaceTiles = new Dictionary<int, TileViewModel>(128);
        }

        public void SetTile(TileType type, int x, int y)
        {
            if (SurfaceTiles.TryGetValue(TilePosition.Hash(x, y), out TileViewModel tile))
            {
                //TileType previous = tile.CurrentType;
                tile.CurrentType = type;
                tile.OnTileChanged = this.OnTileChanged;
                //OnTileChangedEvent?.Invoke(previous, type);
            }
            else
            {
                tile = CreateChangableTile();
                AddTile(TilePosition.Hash(x, y), tile);
                tile.CurrentType = type;
                AddTileCallback(tile, x, y);
            }
        }

        public void SetUneditableTile(TileType type, int x, int y)
        {
            int hash = TilePosition.Hash(x, y);
            if (SurfaceTiles.TryGetValue(hash, out TileViewModel tile))
            {
                // this case should never be reached because its slow
                // there should never be an existing tile at the given X and Y coords
                // instead you should add uneditable tiles in a clever way such that the
                // tile will always be uneditable unfortunately.... i think
                // tho tbh this will never be reached because this is only used by the
                // casing and thats only generated after everythings been cleared
                // i have no clue if this actually works... probably doesnt lol
                // could instead of removing the tile and adding back (in the
                // control) could instead change its datacontext from a
                // changable to unchangable tileviewmodel, but thats not mvvmey so...
                // "SwapViewModel" fuyction... mioght add later
                SurfaceTiles.Remove(hash);
                tile = CreateUnchangableTile();
                AddTile(hash, tile);
                //TileType previous = tile.CurrentType;
                tile.CurrentType = type;
                RemoveTileCallback(tile, x, y);
                AddTileCallback(tile, x, y);
                //OnTileChangedEvent?.Invoke(previous, type);
            }
            else
            {
                tile = CreateUnchangableTile();
                AddTile(hash, tile);
                //TileType previous = tile.CurrentType;
                tile.CurrentType = type;
                AddTileCallback(tile, x, y);
                //OnTileChangedEvent?.Invoke(previous, type);
            }
        }

        public UnchangableTileViewModel CreateUnchangableTile()
        {
            UnchangableTileViewModel tile = new UnchangableTileViewModel();
            tile.OnTileChanged = OnTileChanged;
            return tile;
        }

        public ChangableTileViewModel CreateChangableTile()
        {
            ChangableTileViewModel tile = new ChangableTileViewModel();
            tile.OnTileChanged = OnTileChanged;
            return tile;
        }

        private void OnTileChanged(TileType oldType, TileType newType)
        {
            OnTileChangedEvent?.Invoke(oldType, newType);
        }

        private void AddTile(int hashXY, TileViewModel tile)
        {
            SurfaceTiles.Add(hashXY, tile);
        }

        public void ClearRows()
        {
            ClearRowsCallback();
        }

        public void ClearColumn()
        {
            ClearColumnsCallback();
        }

        public void ClearTiles()
        {
            ClearTilesCallback();
        }
    }
}

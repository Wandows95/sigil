using System;
using System.Collections;
using UnityEngine;

class Grid
{
    private Tile[][] grid;
    int size_x, size_y;

    public Grid(int size_x, int size_y)
    {
        grid = new Tile[size_x][size_y];
        this.size_x = size_x;
        this.size_y = size_y;
    }

    public bool IsFree(int x, int y)
    {
        return !(x < 0 || x >= size_x || y < 0 || y >= size_y) // Bounds
            && !(grid[x][y].is_blocked) // Not blocked
            && (grid[x][y].unit == null); // Not occupied
    }

    public bool MoveUnit(MoveCommand cmd, int x, int y)
    {
        if(IsFree(x, y))
        {
            UnitTag unit = grid[x][y];

            if((unit != null && cmd.player_id == unit.owner_id) 
                && IsFree(x+cmd.mag_x, y+cmd.mag_y))
            {
                grid[x][y] = null;
                grid[x+cmd.mag_x][y+cmd.mag_y] = unit;

                return true;
            }
        }
        
        return false;
    }
}

public struct Tile
{
    public bool is_blocked;
    public UnitTag unit;
}

public struct UnitTag
{
    public int owner_id;
    public int gameobject_id;
    private GameObject _obj;

    public GameObject obj {get{ return _obj; }}
}
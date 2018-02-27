using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Grid : MonoBehaviour
{
    public static int Width = 10;
    public static int Height = 20;
    public static Transform[,] GridArray = new Transform[Width, Height];

    public static bool IsInsideGrid(Vector2 pos)
    {
        return ((int) pos.x >= 0 &&
                (int) pos.x < Width &&
                (int) pos.y >= 0);
    }

    public static void DeleteRow(int y)
    {
        for (int x = 0; x < Width; ++x)
        {
            // TODO do we need to check for null?
            Destroy(GridArray[x, y].gameObject);
            GridArray[x, y] = null;
        }
    }

    public static void DecreaseRow(int y)
    {
        for (int x = 0; x < Width; ++x)        
        {
            if (GridArray[x, y] == null)
            {
                // Move one towards bottom
                GridArray[x, y-1] = GridArray[x, y];
                GridArray[x, y] = null;

                // Update Block position
                GridArray[x, y - 1].position += Vector3.down;
            }
        }
    }

    public static void DecreaseRowsAbove(int y)
    {
        for (int i = y; i < Height; ++i)
        {
            DecreaseRow(i);
        }
    }

    public static bool IsRowFull(int y)
    {
        for (int x = 0; x < Width; ++x)
        {
            if (GridArray[x, y] == null) return false;
        }
        return true;
    }

    public static void deleteFullRows()
    {        
        for (int i = 0; i < Height; ++i)
        {
            if (IsRowFull(i))
            {
                DeleteRow(i);
                DecreaseRowsAbove(i);
                --i;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public const int GridWidth = 10;
    public const int GridHeight = 20;

    public static Vector2 Round(Vector2 pos)
    {
        return new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }
}

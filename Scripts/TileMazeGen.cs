using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMazeGen : MonoBehaviour
{
    public Tilemap tilemap;
    public Vector3Int  position;

    public Tile newTile; 

    [ContextMenu("Paint")]
    void Paint()
    {
        tilemap.SetTile(position, newTile);
    }
    void Start()
    {
        Paint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

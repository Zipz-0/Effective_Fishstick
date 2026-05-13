using System.Collections.Generic;
using UnityEngine;

public class WorldTile : MonoBehaviour
{
   public int gCost;
   public int hCost;
   public int gridX, gridY, gridZ, cellX, cellY, cellZ;
   public bool walkable = true;
   public List<WorldTile> neighbors;
   public WorldTile parent;

    public WorldTile(bool _walkable, int _gridX, int _gridY, int _gridZ)
    {
        walkable = _walkable;
        gridX = _gridX;
        gridY = _gridY;
        gridZ = _gridZ;
    }
   
   public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }
}

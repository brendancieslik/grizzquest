using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEdge
{
    public MapNode from { get; }
    public MapNode to { get; }

    public MapEdge(MapNode f, MapNode t)
    {
        from = f;
        to = t;
    }
    public bool isSame(MapEdge e)
    {
        if (e.from != this.from || e.to != this.to)
            return false;
        return true;
    }


}

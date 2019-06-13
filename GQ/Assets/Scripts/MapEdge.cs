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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

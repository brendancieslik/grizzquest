using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/******************************************************************
 Map Nodes are the spaces on the Map.
 Each vertical row of Nodes shares a Tier.
 The number of Tiers is the number of events per game.
 Edges are the relationship between nodes. 
 If an edge between a Node exists, you may travel 
    from the first to the second.
 *****************************************************************/
public static class Map
{
    public static List<MapEdge> edges { get; set; }
    public static List<MapNode> nodes { get; set; } 
    public const int MAP_SIZE = 40;

    
    public static void CreateMap()
    {
        nodes = new List<MapNode>();
        edges = new List<MapEdge>();
        Event.CreateEventList();
        List<MapNode> prevTier = new List<MapNode>();
        List<MapNode> currTier = new List<MapNode>();
        System.Random rand = new System.Random();

        //Sets up initial tier. This is the node you start at. It will have a null event.
        MapNode initialNode = MapNode.getInitialNode();
        prevTier.Add(initialNode);
        nodes.Add(initialNode);
        //Creates MAP_SIZE number of tiers. 
        for (int i = 1; i <= MAP_SIZE; i++)
        {
            currTier = CreateTier(i, rand);
            CreateTierEdges(prevTier, currTier);
            prevTier = currTier;
        }
    }
    private static List<MapNode> CreateTier(int tier, System.Random r)
    {        
        int nodeCount = r.Next(1, 5);
        List<MapNode> currTier = new List<MapNode>();
        for (int i = 0; i < nodeCount; i++)
        {
            MapNode n = new MapNode();            
            n.tier = tier;
            n.mapEvent = Event.getRandomEvent(r);
            currTier.Add(n);
            nodes.Add(n);            
        }
        return currTier;
    }

    //This method is the meat of the class. It controls how the nodes are related 
    private static void CreateTierEdges(List<MapNode> prev, List<MapNode> curr)
    {
        int prevCount = prev.Count();
        int currCount = curr.Count();

        //if the tiers match, every node corresponds 1-1
        if (prevCount == currCount)
        {
            for (int i = 0; i < prevCount; i++)
            {
                edges.Add(new MapEdge(prev.ElementAt(i), curr.ElementAt(i)));
            }
        }
        //one node always leads to each node.
        else if (prevCount == 1)
        {
            foreach (MapNode n in curr)
            {
                edges.Add(new MapEdge(prev.ElementAt(0), n));
            }
        }
        else if (currCount == 1)
        {
            foreach (MapNode n in prev)
            {
                edges.Add(new MapEdge(n, curr.ElementAt(0)));
            }
        }
        //if prev is exactly 1 less than curr, each prev leads to 2 nodes
        else if (prevCount + 1 == currCount)
        {
            for (int i = 0; i < prevCount; i++)
            {
                edges.Add(new MapEdge(prev.ElementAt(i), curr.ElementAt(i)));
                edges.Add(new MapEdge(prev.ElementAt(i), curr.ElementAt(i + 1)));
            }
        }
        //if prev is exactly 1 less than curr, its same situation as above, except flipped
        else if (prevCount - 1 == currCount)
        {
            for (int i = 0; i < currCount; i++)
            {
                edges.Add(new MapEdge(prev.ElementAt(i), curr.ElementAt(i)));
                edges.Add(new MapEdge(prev.ElementAt(i + 1), curr.ElementAt(i)));
            }
        }
        //final situations are 2-4 or 4-2            
        else if (prevCount == 2 && currCount == 4)
        {
            edges.Add(new MapEdge(prev.ElementAt(0), curr.ElementAt(0)));
            edges.Add(new MapEdge(prev.ElementAt(0), curr.ElementAt(1)));
            edges.Add(new MapEdge(prev.ElementAt(1), curr.ElementAt(2)));
            edges.Add(new MapEdge(prev.ElementAt(1), curr.ElementAt(3)));
        }
        else if (prevCount == 4 && currCount == 2)
        {
            edges.Add(new MapEdge(prev.ElementAt(0), curr.ElementAt(0)));
            edges.Add(new MapEdge(prev.ElementAt(1), curr.ElementAt(0)));
            edges.Add(new MapEdge(prev.ElementAt(2), curr.ElementAt(1)));
            edges.Add(new MapEdge(prev.ElementAt(3), curr.ElementAt(1)));
        }
    }

    public static bool EdgeExists(MapNode prev, MapNode curr)
    {
        MapEdge testEdge = new MapEdge(prev, curr);        
        foreach (MapEdge me in edges)
        {
            //Since these are added in tier order, you only need to check up until you reach the current tier
            //me.from is the MapEdge's first node
            if (me.from.tier > GameState.currentTier)
            {
                return false;
            }
            if (me.isSame(testEdge))
            {                
                return true;
            }
        }
        //If we are on the last node, and somehow an edge doesnt exist...
        //should be unreachable
        return false;
    }
}


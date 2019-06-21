using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class MapCreator : MonoBehaviour
{


    public GameObject Location;
    // Start is called before the first frame update
    void Start()
    {        
        if (GameState.currentTier == 0)
        {
            Map.CreateMap();
            GameState.currentNode = Map.nodes[0];
            
        }
        CreateLocations();
        Event.CreateEventList();
        //Instantiate(Location, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateLocations()
    {
        //This must equal the max map size
        int remainingTiers = 40 - GameState.currentTier;
        for (int i = 0; i < System.Math.Min(10, remainingTiers); i++)
        {
            CreateTier(i);
        }
    }
    public void CreateTier(int offset)
    {
        List<MapNode> thisTier = GetTier(GameState.currentTier + offset);     
        
        switch (thisTier.Count)
        {
            case 1:
                instantiateNode(offset, 500, thisTier[0]);
                break;
            case 2:
                instantiateNode(offset, 300, thisTier[0]);
                instantiateNode(offset, 700, thisTier[1]);
                break;
            case 3:

                instantiateNode(offset, 300, thisTier[0]);
                instantiateNode(offset, 500, thisTier[1]);
                instantiateNode(offset, 700, thisTier[2]);
                break;
            case 4:

                instantiateNode(offset, 200, thisTier[0]);
                instantiateNode(offset, 400, thisTier[1]);
                instantiateNode(offset, 600, thisTier[2]);
                instantiateNode(offset, 800, thisTier[3]);
                break;
        }
        


    }

    //returns a list of nodes for the tier number specified
    public List<MapNode> GetTier(int tier)
    {
        int i = 0;
        List<MapNode> thisTier = new List<MapNode>();
        MapNode currentNode = Map.nodes.ElementAt(i);
        //iterates and finds the first node that meets the requirement
        //this will end up being incredibly inefficient        
        while (Map.nodes[i].tier != tier)
        {            
            i++;
            currentNode = Map.nodes.ElementAt(i);
        }
        while (Map.nodes[i].tier == tier)
        {
            thisTier.Add(currentNode);            
            i++;
            currentNode = Map.nodes.ElementAt(i);
        }
        return thisTier;
    }

    private static void colorCurrentNode(GameObject Loc)
    {
        if (Loc.GetComponent<Location>().locationNode == GameState.currentNode)
        {
            Loc.GetComponent<Image>().color = Color.cyan;
        }
    }

    private void instantiateNode(int offset, int ypos, MapNode node)
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        GameObject newLocation;
        newLocation = Instantiate(Location, new Vector3(150 + offset * 182, ypos, 0), Quaternion.identity);
        newLocation.transform.SetParent(canvas.transform);
        newLocation.GetComponent<Location>().locationNode = node;
        colorCurrentNode(newLocation);
    }
}

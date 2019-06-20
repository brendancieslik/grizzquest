using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        GameObject newLocation0;
        GameObject newLocation1;
        GameObject newLocation2;
        GameObject newLocation3;

        switch (thisTier.Count)
        {
           
            case 1:
                newLocation0 = Instantiate(Location, new Vector3(150 + offset * 182, 500, 0), Quaternion.identity);
                newLocation0.transform.SetParent(canvas.transform);
                newLocation0.GetComponent<Location>().locationNode = thisTier[0];

                break;
            case 2:
                newLocation0 = Instantiate(Location, new Vector3(150 + offset * 182, 300, 0), Quaternion.identity);
                newLocation0.transform.SetParent(canvas.transform);
                newLocation0.GetComponent<Location>().locationNode = thisTier[0];

                newLocation1 = Instantiate(Location, new Vector3(150 + offset * 182, 700, 0), Quaternion.identity);
                newLocation1.transform.SetParent(canvas.transform);
                newLocation1.GetComponent<Location>().locationNode = thisTier[1];
                break;
            case 3:
                newLocation0 = Instantiate(Location, new Vector3(150 + offset * 182, 300, 0), Quaternion.identity);
                newLocation0.transform.SetParent(canvas.transform);
                newLocation0.GetComponent<Location>().locationNode = thisTier[0];

                newLocation1 = Instantiate(Location, new Vector3(150 + offset * 182, 500, 0), Quaternion.identity);
                newLocation1.transform.SetParent(canvas.transform);
                newLocation1.GetComponent<Location>().locationNode = thisTier[1];

                newLocation2 = Instantiate(Location, new Vector3(150 + offset * 182, 700, 0), Quaternion.identity);
                newLocation2.transform.SetParent(canvas.transform);
                newLocation2.GetComponent<Location>().locationNode = thisTier[2];
                break;
            case 4:
                newLocation0 = Instantiate(Location, new Vector3(150 + offset * 182, 200, 0), Quaternion.identity);
                newLocation0.transform.SetParent(canvas.transform);
                newLocation0.GetComponent<Location>().locationNode = thisTier[0];

                newLocation1 = Instantiate(Location, new Vector3(150 + offset * 182, 400, 0), Quaternion.identity);
                newLocation1.transform.SetParent(canvas.transform);
                newLocation1.GetComponent<Location>().locationNode = thisTier[1];

                newLocation2 = Instantiate(Location, new Vector3(150 + offset * 182, 600, 0), Quaternion.identity);
                newLocation2.transform.SetParent(canvas.transform);
                newLocation2.GetComponent<Location>().locationNode = thisTier[2];

                newLocation2 = Instantiate(Location, new Vector3(150 + offset * 182, 800, 0), Quaternion.identity);
                newLocation2.transform.SetParent(canvas.transform);
                newLocation2.GetComponent<Location>().locationNode = thisTier[3];
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
}

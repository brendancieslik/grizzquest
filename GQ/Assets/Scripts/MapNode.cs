using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapNode : MonoBehaviour
{

    public Event mapEvent;
    public int tier { get; set; }

    void Start()
    {

        Event.CreateEventList();
        mapEvent = Event.getRandomEvent();

        Debug.Log(mapEvent.text);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static MapNode getInitialNode()
    {
        MapNode initial = new MapNode();
        initial.tier = 0;
        initial.mapEvent = null;
        return initial;
    }

    public void LoadGameEvent(MapNode n)
    {
        GameState.currentEvent = n.mapEvent;

        Debug.Log(n.mapEvent.text);
        //Debug.Log(GameState.currentEvent.text);
        SceneManager.LoadScene(1);
    }

}

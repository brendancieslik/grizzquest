using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapNode
{

    public Event mapEvent { get; set; }
    public int tier { get; set; }

    public static MapNode getInitialNode()
    {
        MapNode initial = new MapNode();
        initial.tier = 0;
        //create the first event
        Event initialEvent = new Event();
        initialEvent.text = "Start!";        
        EventOption option = new EventOption();
        option.text = "ok.";
        List<EventOption> options = new List<EventOption>();
        options.Add(option);
        initialEvent.options = options;

        initial.mapEvent = initialEvent;
        return initial;
    }


}

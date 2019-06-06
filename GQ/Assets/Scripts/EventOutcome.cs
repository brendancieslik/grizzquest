using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventOutcome 
{
    public int chance { get; set; }
    public string text { get; set; }
    public string battleValue { get; set; }
    public IEnumerable<EventReward> rewards { get; set; }

    public EventOutcome()
    {

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

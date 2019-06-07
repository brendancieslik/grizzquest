using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventOption
{
    public string text { get; set; }
    public IEnumerable<EventOutcome> outcomes { get; set; }

    public EventOption()
    {

    }

    public EventOutcome getRandomOutcome()
    {
        System.Random r = new System.Random();
        int randomRoll = r.Next(0, 99);
        foreach (EventOutcome o in outcomes)
        {
            if (randomRoll < o.chance)
                return o;
            else
                randomRoll -= o.chance;
        }
        //As long as the chances of all outcomes add up to 100% The above foreach will return an outcome 



        //Unity doesnt like the word exception? So I return null instead. This will break intended behavior.
        return null;
        //throw new Exception("Invalid EventOption. Sum of EventOutcome chances =/= 100");

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

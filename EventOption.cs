
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophProj
{
    //options are what the player selects when viewing an event
    class EventOption
    {
        public string text { get; set; }
        public IEnumerable<EventOutcome> outcomes { get; set; }

        public EventOption()
        {            

        }

        public EventOutcome getRandomOutcome()
        {
            Random r = new Random();
            int randomRoll = r.Next(0, 99);            
            foreach (EventOutcome o in outcomes)
            {
                if (randomRoll < o.chance)
                    return o;
                else
                    randomRoll -= o.chance;
            }
            //As long as the chances of all outcomes add up to 100% The above foreach will return an outcome 
            throw new Exception("Invalid EventOption. Sum of EventOutcome chances =/= 100");

        }
    }
}

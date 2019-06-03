
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophProj
{
    //outcomes represent the random chance  within each EventOption
    class EventOutcome
    {
        public int chance { get; set; }
        public string text { get; set; }
        public string battleValue { get; set; }
        public IEnumerable<EventReward> rewards { get; set; }

        public EventOutcome()
        {            
            
        }
    }
}

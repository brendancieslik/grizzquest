using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophProj
{
    class MapNode
    {
        Event mapEvent;
        public int tier { get; }

        public MapNode(int t)
        {
            mapEvent = Event.getRandomEvent();
            tier = t;
        }

        public static MapNode getInitialNode()
        {
           MapNode initial = new MapNode(0);
            initial.mapEvent = null;
            return initial;
        }

    }
}

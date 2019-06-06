using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophProj
{
    class MapEdge
    {
        public MapNode from { get; }
        public MapNode to { get; }

        public MapEdge(MapNode f, MapNode t)
        {
            from = f;
            to = t;
        }

    }
}

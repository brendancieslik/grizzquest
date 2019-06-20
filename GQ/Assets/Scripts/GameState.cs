using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    public static Event currentEvent { get; set; }
    public static MapNode currentNode { get; set; }
    public static int currentTier { get; set; }

}

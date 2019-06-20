using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Location : MonoBehaviour
{

    public MapNode locationNode { get; set; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void LoadGameEvent()
    {
        if (Map.EdgeExists(GameState.currentNode, locationNode))
        {
            GameState.currentNode = locationNode;
            GameState.currentEvent = locationNode.mapEvent;
            GameState.currentTier++;
            SceneManager.LoadScene(1);
        }
    }
}

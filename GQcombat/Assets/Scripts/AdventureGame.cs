using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class AdventureGame : MonoBehaviour
{
    EventUI eventUI;
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    
    State state;

    // Use this for initialization
    void Start()
    {
        state = startingState;
        //textComponent.text = state.GetStateStory();
        
        LoadInitialData();        
        Event currentEvent = Event.getRandomEvent();
        eventUI = new EventUI(currentEvent);
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
                
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            eventUI.KeyPress(0);          
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            eventUI.KeyPress(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            eventUI.KeyPress(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            eventUI.KeyPress(3);
        }
        eventUI.displayEvent();
        
    }

    private void LoadInitialData()
    {
        Event.CreateEventList();
    }


    

}

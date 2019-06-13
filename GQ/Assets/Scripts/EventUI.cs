using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class EventUI
{

    private static Text storyText = GameObject.Find("storyPrompt").GetComponent<Text>();
    private static Text option1 = GameObject.Find("optionText1").GetComponent<Text>();
    private static Text option2 = GameObject.Find("optionText2").GetComponent<Text>();
    private static Text option3 = GameObject.Find("optionText3").GetComponent<Text>();
    private static Text option4 = GameObject.Find("optionText4").GetComponent<Text>();
    Event currentEvent { get; set; }
    private EventOutcome selectedOutcome;

    public EventUI()
    {
        currentEvent = GameState.currentEvent;
    }

    public void displayEvent()
    {
        ReloadUIElements();
        clearOptions();
        if (!currentEvent.hasChosen)
        {
            storyText.text = currentEvent.text;
            //TODO: Check for reqs first before showing the options

            List<Text> optionTexts = getOptionUIList();
            int index = 0;
            EventOption currentOption = new EventOption();

            foreach (EventOption o in currentEvent.options)
            {
                optionTexts[index].text = (index + 1) + ". " + o.text;
                index++;
            }
        }
        else
        {
            storyText.text = selectedOutcome.text;
            option1.text = "1. Ok.";
        }
    }

    private List<Text> getOptionUIList()
    {
        List<Text> optionTexts = new List<Text>();
        optionTexts.Add(option1);
        optionTexts.Add(option2);
        optionTexts.Add(option3);
        optionTexts.Add(option4);
        return optionTexts;
    }

    private void clearOptions()
    {
        option1.text = "";
        option2.text = "";
        option3.text = "";
        option4.text = "";

    }

    private void ReloadUIElements()
    {
        storyText = GameObject.Find("storyPrompt").GetComponent<Text>();
        option1 = GameObject.Find("optionText1").GetComponent<Text>();
        option2 = GameObject.Find("optionText2").GetComponent<Text>();
        option3 = GameObject.Find("optionText3").GetComponent<Text>();
        option4 = GameObject.Find("optionText4").GetComponent<Text>();
    }

    public void SelectOption(int selection)
    {
        currentEvent.hasChosen = true;
        selectedOutcome = currentEvent.options.ElementAt(selection).getRandomOutcome();
    }

    public void KeyPress(int selection)
    {
        if (!currentEvent.hasChosen)
        {
            SelectOption(selection);
            //TODO: Give rewards
        }
        else
        {
            //2 is the Map Scene index. This will load back into the map if the selection was already pressed.
            SceneManager.LoadScene(2);
        }
    }
}

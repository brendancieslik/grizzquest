using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class CombatUI
{
    private static Text basicAttack = GameObject.Find("basicAttack").GetComponent<Text>();
    private static Text powerAttack = GameObject.Find("powerAttack").GetComponent<Text>();
    private static Text preciseAttack = GameObject.Find("preciseAttack").GetComponent<Text>();
    private static Text flee = GameObject.Find("flee").GetComponent<Text>();
    Monster currentMonster { get; set; }
    private Character player { get; set; }
    private combatResults results;


	public CombatUI(Character playerNow,Monster enemy)
	{
        player = playerNow;
        currentMonster = enemy;
	}

    public void SelectOption(int selection)
    {
        if (selection =  0)
        {
            player.basicAttack();
            CombatUI.attackRound(player, currentMonster);

        }
    }

    public void KeyPress(int selection)

    {
        SelectOption(selection);
    }


}

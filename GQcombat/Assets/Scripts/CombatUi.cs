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
    public Monster currentMonster { get; set; }
    public Character player { get; set; }


	public CombatUI(Character playerNow,Monster enemy)
	{
        player = playerNow;
        currentMonster = enemy;
	}

    public void SelectOption(int selection)
    {
        switch (selection)
        {
            case 0:
                player.BasicAttack();
                Combat.AttackRound(player, currentMonster);
                player.ResetModifiers();
                break;
            case 1:
                player.PowerAttack();
                Combat.AttackRound(player, currentMonster);
                player.ResetModifiers();
                break;
            case 2:
                player.PreciseAttack();
                Combat.AttackRound(player, currentMonster);
                player.ResetModifiers();
                break;
            case 3:
                Combat.flee(player, currentMonster);
                break;
        }
    }

    public void KeyPress(int selection)
    {
        SelectOption(selection);
    }
    public int NewPlayerHealth(int hp)
    {
        return player.getcurrentHealth;
    }


}

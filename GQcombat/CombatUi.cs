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
    monster currentMonster { get; set; }
    private combatResults results;


	public CombatUI(monster m)
	{
        currentMonster = m;
	}


}

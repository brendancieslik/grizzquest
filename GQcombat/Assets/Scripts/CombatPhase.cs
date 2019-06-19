using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CombatPhase : MonoBehaviour
{
    CombatUI combatUI;
    [SerializeField] Text textComponent;
    State state;
    private static Text playerHealth = GameObject.Find("playerHealth").GetComponent<Text>;
    private static Text monsterHealth = GameObject.Find("monsterHealth").GetComponent<Text>;
    Character character1 = new Character(10, 10, 10, 10);

    void Start()
    {
        LoadInitialData();
        combatUI = new CombatUI(character1,Monster.getRandomMonster(1));
    }
    void Update()
    {
        ManageState();
        playerHealth.text = combatUI.player.getcurrentHealth();
        monsterHealth.text = combatUI.currentMonster.getcurrentHealth();
    }
    private void ManageState()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            combatUI.KeyPress(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        { 
            combatUI.KeyPress(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            combatUI.KeyPress(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            combatUI.KeyPress(3);
        }
    }
    private void LoadInitialData()
    {
        Monster.CreateMonsterList();
    }
}

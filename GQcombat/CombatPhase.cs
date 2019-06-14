using System;

public class CombatPhase : MonoBehaviour
{
    CombatUI combatUI;
    [SerializeField] Text textComponent;
    State state;
    private static Text playerHealth = GameObject.Find("playerHealth").GetComponent<Text>;
    private static Text monsterHealth = GameObject.Find("monsterHealth").GetComponent<Text>;

    void Start()
    {
        LoadInitialData();
        combatUI = new CombatUI();
    }
    void Update()
    {
        ManageState();

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
        Monster.getRandomMonster(1);
    }
    private void updateHealth()
    {
        playerHealth = 
    }
}

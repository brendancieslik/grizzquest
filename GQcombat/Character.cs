using System;

public class Character
{
    
    public int strength { get; set; }
    public int dexterity { get; set; }
    public int intelligence { get; set; }
    public int vitality { get; set; }
    public int maxHealth { get; set; }
    public int currentHealth { get; set; }
    public int armorRating { get; set; }
    public int attackModifier { get; set; }
    public int damageModifier { get; set; }

    public Character(int str, int dex, int intelli, int max, int current, int armor, int atk, int dmg)
    {
        strength = str;
        dexerity = dex;
        intelligence = intelli;
        maxHealth = max;
        currentHealth = current;
        armorRating = armor;
        attackModifier = atk;
        damageModifier = dmg;
        maxHealth = vitality * 10;
        currentHealth = maxHealth;
        attackModifer = 0;
        damageModifer = 0;
    }
    public void basicAttack()
    { }
    public void powerAttack()
    {
        attackModifier -= 2;
        damageModifier += 2;
    }
    public void preciseAttack()
    {
        attackModifier += 2;
        damageModifier -= 2;
    }
}


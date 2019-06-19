using System;

public class Character
{

    public int strength { get; set; }
    public int dexterity { get; set; }
    public int intelligence { get; set; }
    public int vitality { get; set; }
    public int maxHealth { get; set; }
    public int currentHealth { get; set; }
    public int armorClass { get; set; }
    public int attackModifier { get; set; }
    public int damageModifier { get; set; }

    public Character(int str, int dex, int intelli, int vit)
    {
        strength = str;
        dexterity = dex;
        intelligence = intelli;
        vitality = vit;
        maxHealth = vitality * 10;
        currentHealth = maxHealth;
        armorClass = dex;
        maxHealth = vitality * 10;
        currentHealth = maxHealth;
        resetModifiers();
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
    public void resetModifiers()
    {
        attackModifier = dexterity;
        damageModifier = strength;
    }
}


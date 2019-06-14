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
        dexerity = dex;
        intelligence = intelli;
        vitality = vit;
        maxHealth = vitality * 10;
        currentHealth = maxHealth;
        armorClass = dex;
        maxHealth = vitality * 10;
        currentHealth = maxHealth;
        resetModifiers();
    }
    private void basicAttack()
    { }
    private void powerAttack()
    {
        attackModifier -= 2;
        damageModifier += 2;
    }
    private void preciseAttack()
    {
        attackModifier += 2;
        damageModifier -= 2;
    }
    private void resetModifiers()
    {
        attackModifier = dexerity;
        damageModifier = strength;
    }
}


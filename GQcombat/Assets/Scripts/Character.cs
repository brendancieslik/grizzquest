public class Character
{

    private int Strength { get; set; }
    private int Dexterity { get; set; }
    private int Intelligence { get; set; }
    private int Vitality { get; set; }
    private int MaxHealth { get; set; }
    private int CurrentHealth { get; set; }
    private int ArmorClass { get; set; }
    private int AttackModifier { get; set; }
    private int DamageModifier { get; set; }

    public Character(int str, int dex, int intelli, int vit)
    {
        Strength = str;
        Dexterity = dex;
        Intelligence = intelli;
        Vitality = vit;
        MaxHealth = Vitality * 10;
        CurrentHealth = MaxHealth;
        ArmorClass = dex;
        MaxHealth = Vitality * 10;
        CurrentHealth = MaxHealth;
        ResetModifiers();
    }
    public void BasicAttack()
    { }
    public void PowerAttack()
    {
        AttackModifier -= 2;
        DamageModifier += 2;
    }
    public void PreciseAttack()
    {
        AttackModifier += 2;
        DamageModifier -= 2;
    }
    public void ResetModifiers()
    {
        AttackModifier = Dexterity;
        DamageModifier = Strength;
    }
}


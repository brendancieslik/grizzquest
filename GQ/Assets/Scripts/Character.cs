using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    StatBar hpBar;

    private int hp;
    private int str;
    private int agl;
    private int inte;
    private int vit;



    private int maxHp;

    public Character()
    {
        
        maxHp = 100;
        hp = 100;
        str = 0;
        agl = 0;
        inte = 0;
        vit = 0;
    }
    public void setStatVal(int StatValue, string StatType)
    {
        if (StatType == "hp")
        {
            hp += StatValue;
            hpBar.MyCurrentStatValue = hp;
            if (hp > maxHp)
                hp = maxHp;
        }
        else if (StatType == "str")
        {
            str += StatValue;
        }
        else if (StatType == "agl")
        {
            agl += StatValue;
        }
        else if (StatType == "inte")
        {
            inte += StatValue;
        }
        else if (StatType == "vit")
        {
            vit += StatValue;
        }
    }








}

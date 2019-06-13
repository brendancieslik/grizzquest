using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

public class Combat
{
    public int difficulty { get; set; }
    public int attackModifier { get; set; }
    public int damageModifier { get; set; }

    public int attackRoll(int attack)
    {
        attackModifier += attack;
        System.Random r = new System.Random();
        int roll = r.Next(1, 10) + attackModifier;
        return roll;
    }
    public int damageRoll(int damage)
    {
        damageModifier += damage;
        System.Random r = new System.Random();
        int roll = r.Next(1, 10) + attackModifier;
        return roll;
    }




}

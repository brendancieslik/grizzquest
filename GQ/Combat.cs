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
    public int attackModifier { get; set; }

    public int diceRoll()
    {
        System.Random r = new System.Random();
        int roll = r.Next(1, 10);
        return roll;
    }
    public int Combat(character player, monster enemy)
    {
        if (diceRoll() + attackModifier >= enemy.getarmorRating()
    }




}

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
    public AttackRound(Character player, Monster enemy)
    {
        if ((diceRoll() + player.getattackModifer()) > enemy.getarmorClass())
        {
            enemy.setcurrentHealth(enemy.getcurrentHealth() - damageRoll(player));
            if (enemy.getcurrentHealth <= 0)
            {
                //TODO make method to return to map screen
            }
            else
            {
                if (diceRoll() + enemy.getattackModifier() > player.getarmorClass())
                {
                    player.setcurrentHealth(player.getcurrentHealth() - damageRoll(enemy));
                    if (player.getcurrentHealth() <= 0)
                    {
                        //TODO go to game over screen
                    }
                }
            }

        }
            
    }
    public int monsterAttack(Character player, Monster enemy)
    {
        if (diceRoll() + enemy.getattackModifier() > player.getarmorClass())
        {
            player.setcurrentHealth(player.getcurrentHealth() - damageRoll(enemy));
            if (player.getcurrentHealth() <= 0)
            {
                //TODO go to game over screen
            }
        }
    }
    public int damageRoll(Character player)
    {
        //TODO double damage if diceRoll() = 10
        int damage = diceRoll() + player.getdamageModifier;
        return damage;
    }
    public int damageRoll(Monster enemy)
    {
        int damage = diceRoll() + enemy.getdamageModifier;
        return damage;
    }
    public int diceRoll()
    {
        System.Random r = new System.Random();
        int roll = r.Next(1, 10);
        return roll;
    }
    public void flee(Character player, Monster enemy)
    {
        if (Combat.diceRoll() + player.getDexerity() >= Combat.diceRoll + enemy.getDexerity())
        {
            //TODO change state back to map screen
        } else {
        monsterAttack(player, enemy);                
        }

        
    }


}

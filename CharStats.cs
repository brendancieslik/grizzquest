using System.Collections.Generic;
using System;

public class CharStat
{
    public float BaseVal;

    public float Value
    {
        get
        {
            return CalcFinalVal();
        }
    }

    private readonly List<StatMod> statMod;

    public CharStat(float baseVal)
    {
        BaseVal = baseVal;
        statMod = new List<StatMod>();
    }
    public void AddMod(StatMod mod)
    {
        statMod.Add(mod);
    }
    public bool RemoveMod(StatMod mod)
    {
        return statMod.Remove(mod);
    }
    private float CalcFinalVal()
    {
        float finalVal = BaseVal;
        for(int i = 0; i < statMod.Count; i++)
        {
            finalVal += statMod[i].Value; 
        }
        return (float)Math.Round(finalVal, 4); 
    }
}

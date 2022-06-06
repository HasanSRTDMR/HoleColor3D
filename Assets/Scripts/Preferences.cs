using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Preferences 
{
    public static string gold = "gold";

    public static void GoldAssignValue(int gold)
    {
        PlayerPrefs.SetInt(Preferences.gold, gold);
    }
    public static int GoldReadValue()
    {
        return PlayerPrefs.GetInt(Preferences.gold);
    } 
    public static bool HaveRecord()
    {
        if (PlayerPrefs.HasKey(gold))
        {
            return true;
        }
        else
        {
            return false;
        }
    }  
}

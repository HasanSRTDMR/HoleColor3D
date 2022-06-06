using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static int gold;
    private void Start()
    {
        if (!Preferences.HaveRecord())
        {
            Preferences.GoldAssignValue(0);
        }
        gold = Preferences.GoldReadValue();
    }
    public void AddGold()
    {
        gold += 100;
        Preferences.GoldAssignValue(gold);
    }

}

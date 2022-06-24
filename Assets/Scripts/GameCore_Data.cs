using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameCore_Data
{
    public static bool finished = false;
    public static GameObject pl, tx, au1, au2;
    static GameCore_Data()
    {
        pl = GameObject.Find("Player");
        tx = GameObject.Find("Text");
        au1 = GameObject.Find("Audio1");
        au2 = GameObject.Find("Audio2");
        tx.SetActive(false);
    }
}

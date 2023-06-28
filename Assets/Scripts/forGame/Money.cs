using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public static class Money 
{
    static string MONEY = "duhvbdufbuh";

    public static event Action onMoneyChanged = delegate { };

    public static bool CanBuy(int cnt)
    {
        return MoneyLeft() >= cnt;
    }

    public static int MoneyLeft()
    {
        return PlayerPrefs.GetInt(MONEY);
    }

    public static void AddMoney(int cnt)
    {
        WasteMoney(-cnt);
    }

    public static void WasteMoney(int cnt)
    {
        PlayerPrefs.SetInt(MONEY, MoneyLeft() - cnt);
        onMoneyChanged();
    }
}

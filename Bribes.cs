using UnityEngine;
using System.Collections;
using System;

public class Bribes : MonoBehaviour {
    public float timeOfBribe = 10.0f;
    public int bribeMultiplier = 10;
    public int bribes = 1;
    public float moneyPerSec = 2.0f;
    public float minusTime = 1.0f;
    public MoneyManager money;

    public void OnBribeStart()
    {
        if (bribes >0)
        {
           //ameObject.SetActive(false);
            money.goldperclick *= 10;
            Invoke("OnBribeEnd", 10);
            print("calling");
        }
        
    }

   public void OnBribeEnd()
    {
        money.goldperclick = money.goldperclick / 10;   
        gameObject.SetActive(true);
        bribes--;
    }
}

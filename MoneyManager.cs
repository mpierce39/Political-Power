using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {
    
    public float currentCost;
    public float gold = 0.00f;
    public float goldperclick = 1;
    public Color standard;
    public Color affordable;
    public float TickForOne = 1;
    public float goldPerSec = 0;
    public Image buttonImage;
    public string itemName;
    public Items[] itemsToBuy;
    public Items  Items;
    public float cost = 0;
    public UI ui;
    public float bribes = 0;
    

	// Use this for initialization
	void Start () 
    {
        StartCoroutine(AutoTick());        
    }
    void Update() {
        if (gold > 1000000000)
        {
            ui.ShowWinPanel(true);           
        }
    }    
    public void Clicked()
    {
        gold += goldperclick;        
    }
    IEnumerator AutoTick()
    {       
        int i = 0;
        float gps = goldPerSec / 10f;
        while (true)            
        {
            if (i > 9)
            {
                i = 0;
                gps = goldPerSec / 10f;               
            }
            gold += gps;
            ++i;
            ui.DisplayTotalMoney();
            yield return new WaitForSeconds(0.10f);
        }
    }
    public bool IsAffordable(int index)
    {
        return gold >= itemsToBuy[index].baseCost;
    }
    public void ClickedMoneyPerSecond(int index)
    {
        if (IsAffordable(index))
        {
            cost = itemsToBuy[index].baseCost;
            gold -= cost;           
            itemsToBuy[index].count += 1;
            itemsToBuy[index].baseCost = cost * itemsToBuy[index].baseMultiplierForCost;
            goldPerSec += itemsToBuy[index].CurrentTickValue;
            itemsToBuy[index].CurrentTickValue = (itemsToBuy[index].count == 1) ? TickForOne : itemsToBuy[index].CurrentTickValue * itemsToBuy[index].multiplierForTickValue;           
            ui.DisplayGoldPerSec(goldPerSec);                      
        }
    }
        public void PurchasedClick(int index)
    {

        if (IsAffordable(index))
        {
            cost = itemsToBuy[index].baseCost;
            gold -= cost;
            goldperclick += itemsToBuy[index].CurrentTickValue;
            itemsToBuy[index].CurrentTickValue = (itemsToBuy[index].count == 1) ? TickForOne : itemsToBuy[index].CurrentTickValue * 1.1f;
            itemsToBuy[index].baseCost = cost * itemsToBuy[index].baseMultiplierForCost;
            ui.DisplayGoldPerClick(goldperclick);
        }
    }
}
   



    

    



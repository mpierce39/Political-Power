using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UI : MonoBehaviour {
    public UnityEngine.UI.Text gpc;
    public UnityEngine.UI.Text goldDisplay;

    [SerializeField]
    public UnityEngine.UI.Text[] itemInfo;
    public UnityEngine.UI.Text[] itemCount;
    public UnityEngine.UI.Text gpsDisplay;
    public UnityEngine.UI.Button winButton;
    public Image[] buttonImage;
    public MoneyManager money;
    public Items[] itemsToShow;
    public Items items;
    Animator anim;
    public GameObject LeftPanel;
    public GameObject campaign;
    public bool aMenuOpen = false;
    public GameObject settingsMenu;
    public GameObject shopMenu;
  
    void Start () 
    {		
        anim = GetComponent<Animator>();       
	}

    public void DisplayTotalMoney()
    {
        goldDisplay.text = FormatMoneyText(money.gold);
    }

    public void DisplayGoldPerClick(float goldPerClick) 
    {        
        gpc.text = FormatMoneyText(goldPerClick);
    }

    public void DisplayGoldPerSec(float goldPerSec)
    {
        gpsDisplay.text = FormatMoneyText(goldPerSec);
    }

    public void ClickedMoneyPerSec(int index)
    {
        money.ClickedMoneyPerSecond(index);
        ShowValues(index);	
    }
    //handles displaying button text
    public void ShowValues(int index)
    {
        float cost = money.itemsToBuy[index].baseCost;

        itemInfo[index].text = FormatMoneyText(cost);
        string baseCount = string.Format("{0}", money.itemsToBuy[index].count);
        string baseIncrease = string.Format("{0:0.00}", money.itemsToBuy[index].CurrentTickValue);
        itemCount[index].text = baseCount + "\n" + baseIncrease;
    }

    private string FormatMoneyText(float value)
    {
        //assume showing in millions
        string format = "{0:0.00}M";
        float divisor = 1000000f;

        if (value < 1000)
        {
            //less than 1k in money, just show full amount
            format = "{0:0.00}";
            divisor = 1f;
        }
        else if (value < 1000000)
        {
            //between 1000 and 1000000 show in thousands
            format = "{0:0.00}K";
            divisor = 1000f;
        }

        return string.Format(format, value / divisor);
    }

    //calls moneyManager click method
    public void ClickedMoneyPerClick(int index)
    {
        money.PurchasedClick(index);
        ShowValues(index);
    }
	public void setValues()
    {
		int indexPos = 0;
		int i;
		for(i = 0; i<= 9; i++) 
        {
			indexPos++;
			ClickedMoneyPerSec(indexPos);            
	    }
    }
    public void ActivateSupporterMenu(bool menu)
    {
        LeftPanel.SetActive(true);
        aMenuOpen = true;
    }
    public void closeSupporterMenu()
    {
        LeftPanel.SetActive(false);
        aMenuOpen = false;
    }
    public void OpenCampaignMenu() 
    {
        campaign.SetActive(true);
        aMenuOpen = true;
    }
    public void CloseCampaignMenu() 
    {
        campaign.SetActive(false);
        aMenuOpen = false;
    }
    public void OpenSettingsMenu() 
    {
        settingsMenu.SetActive(true);
        aMenuOpen = true;
    }
    public void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
        aMenuOpen = false;
    }
    public void ShowWinPanel(bool result) 
    {

        if (result == true)
        {
            winButton.gameObject.SetActive(true);
        }       
    }
    public void OpenShopMenu()
    {
        shopMenu.gameObject.SetActive(true);
        aMenuOpen = true;
    }
    public void CloseShopMenu()
    {
        shopMenu.gameObject.SetActive(false);
        aMenuOpen = false;
    }
}

 

        



    


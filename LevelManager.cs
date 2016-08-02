using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void OnTrumpClick()
    {
        SceneManager.LoadScene(1);
    }
	
	public void OnHillaryClick()
    {
        SceneManager.LoadScene(2);
    }
    public void OnWinClick()
    {
        SceneManager.LoadScene(0);
    }
   
}

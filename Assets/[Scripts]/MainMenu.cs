using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
 
    public void GameStart()
    {      
        SceneManager.LoadScene("Level1");
    }
    public void TutoStart()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void EndGame()
    {
        Application.Quit();
    }
  
}

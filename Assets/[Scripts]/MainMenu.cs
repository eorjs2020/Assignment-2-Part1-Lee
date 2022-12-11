//MainMenu
//LastUpdate 22_11_21
//Daekoen_Lee 101076401
//Revision History
//First modified 22_11_21 - Build and Making Script
//Description - MainMenu controller

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        SoundManager.Instance.PlayMusic(Sound.MAIN_MUSIC);
    }

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

//GameController
//LastUpdate 22_11_21
//Daekoen_Lee 101076401
//Revision History
//First modified 22_11_21 - Build and Making Script
//Description - GameController

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : Singleton<GameController>
{
    public GameObject onScreenContols;
    public TMP_Text Life;

    // Start is called before the first frame update
    void Awake()
    {
        onScreenContols = GameObject.Find("OnScreenContols");

        onScreenContols.SetActive(Application.isMobilePlatform);        
    }

    public void ChangeHealth()
    {
        Life.text = Data.Instance.health.ToString();
    }

}

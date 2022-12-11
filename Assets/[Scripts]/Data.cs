//Data
//LastUpdate 22_12_11
//Daekoen_Lee 101076401
//Revision History
//First modified 22_11_21 - Build and Making Script
//Second modified 22_12_11 - put duplication check and destroy systme.
//Description - Databas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Data : Singleton<Data>
{
    private void Awake()
    {
        var obj = FindObjectsOfType<Data>();
        if (obj.Length == 1)
        {           
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    public int health = 5;
    public int score;

    public void GetScore(int score)
    {
        this.score += score;
    }

    public void ResetHealth()
    {
        this.health = 5;
    }
}

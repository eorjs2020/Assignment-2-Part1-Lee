//Goal
//LastUpdate 22_11_21
//Daekoen_Lee 101076401
//Revision History
//First modified 22_11_21 - Build and Making Script
//Description - Goal system that makes game win.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        Data.Instance.score += Data.Instance.health * 400;

        SceneManager.LoadScene("ScoreScene");
    }
}

//CheckPoint
//LastUpdate 22_11_21
//Daekoen_Lee 101076401
//Revision History
//First modified 22_11_21 - Build and Making Script
//Description - Player check point(saving point), if player is dead(if have enought life), Player back to save point.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
                        
            FindObjectOfType<DeathPlaneController>().playerSpawnPoints = transform;
            

        }
    }
}

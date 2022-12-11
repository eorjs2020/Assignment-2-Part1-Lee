//DeathPlaneController
//LastUpdate 22_11_21
//Daekoen_Lee 101076401
//Revision History
//First modified 22_11_21 - Build and Making Script
//Description - DeathPlaneController - if Player touchthe death plain turn back to the save points


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DeathPlaneController : MonoBehaviour
{
    public Transform playerSpawnPoints;

    public void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.gameObject.name == "Player")
        {
            
            ReSpawn(collision.gameObject);
        }
    }

    public void ReSpawn(GameObject go)
    {
        go.transform.position = playerSpawnPoints.position;
    }
}

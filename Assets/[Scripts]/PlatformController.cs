//PlatformController
//LastUpdate 22_11_21
//Daekoen_Lee 101076401
//Revision History
//First modified 22_11_21 - Build and Making Script
//Description - PlatformController - if player collide with platform, platform will make player to child.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.transform.SetParent(transform);
    }
    public void OnCollisionExit2D(Collision2D other)
    {
        other.gameObject.transform.SetParent(null);
    }
}

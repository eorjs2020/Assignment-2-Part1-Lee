//BackGroundPallax
//LastUpdate 22_11_21
//Daekoen_Lee 101076401
//Revision History
//First modified 22_11_21 - Build and Making Script
//Description - Scrolling background system

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundParallax : MonoBehaviour
{
    private float length, startposX, startposY;
    public GameObject cam;
    public float parallaxEffect;
    public bool isYmoving;

    void Start()
    {
        startposY = transform.position.y;
        startposX = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (cam.transform.position.x * parallaxEffect);
        float yDist = (cam.transform.position.y * parallaxEffect);
       transform.position = new Vector3(startposX + dist, transform.position.y, transform.position.z);
    }
}

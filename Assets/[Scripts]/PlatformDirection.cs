//PlatformDirection
//LastUpdate 22_11_21
//Daekoen_Lee 101076401
//Revision History
//First modified 22_11_21 - Build and Making Script
//Description - enum for Platform direction

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum PlatformDirection
{
    HORIZONTAL,
    VERTICAL,
    DIAGONAL_UP,
    DIAGONAL_DOWN,
    CUSTOM,
    DISAPPEAR
}

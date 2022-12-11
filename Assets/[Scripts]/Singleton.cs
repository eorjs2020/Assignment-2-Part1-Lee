//Singleton
//LastUpdate 22_11_21
//Daekoen_Lee 101076401
//Revision History
//First modified 22_11_21 - Build and Making Script
//Description - Singleton system.
// if you want to make singleton, put singleton<clasname>
// ex) public class Example : Singleton<Example> (when you making class)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
            }
            return instance;
        }
    }
}

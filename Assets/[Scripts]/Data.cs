using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Data : Singleton<Data>
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public int health { get; set; }
    public int score { get; set; }    
}

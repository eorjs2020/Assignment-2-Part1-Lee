using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        Data.Instance.score = Data.Instance.health * 400;

        SceneManager.LoadScene("ScoreScene");
    }
}

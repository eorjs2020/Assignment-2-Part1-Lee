//EndState
//LastUpdate 22_11_21
//Daekoen_Lee 101076401
//Revision History
//First modified 22_12_11 - Added Music
//Description - EndState controller

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndState : MonoBehaviour
{
    public Text State;
    public Text Score;
    private Data data;
    private void Start()
    {
        SoundManager.Instance.PlayMusic(Sound.END_MUSIC);
        if (Data.Instance?.health > 0)
        {
            State.text = "Win";
            Score.text = Data.Instance.score.ToString();
        }
        else
        {
            State.text = "Loss";
            Score.text = "";
        }
    }

    public void BacktoMain()
    {
        data = GameObject.FindObjectOfType<Data>();
        if(data)Destroy(data.gameObject);
        SceneManager.LoadScene("MenuScreen");
    }
}

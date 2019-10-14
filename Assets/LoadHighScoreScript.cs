using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadHighScoreScript : MonoBehaviour
{
    public Text text;

    void Start()
    {
        text.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}

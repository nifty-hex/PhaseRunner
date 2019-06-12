using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadScoreScript : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists("ScoreData.txt"))
        {
            var textFile = File.OpenText("ScoreData.txt");
            var line = textFile.ReadLine();
            text.text = "Score: " + line;
            textFile.Close();
        }
    }
}
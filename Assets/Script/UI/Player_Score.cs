using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour
{
    public GameObject player;
    public Player_Health player_hp;
    public int player_score;
    public int score2; //non static use
    Text ScoreText;
    float start_x;
    private AudioManager audiomanager;
    bool playedEasy = false;
    bool playedMedium = false;
    bool playedHard = false;

    // Start is called before the first frame update
    void Start()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        player_score = 900;
        start_x = player.transform.position.x;
        ScoreText = GetComponent<Text>();
    }

    void Update()
    {
        ScoreText.text = "Score: " + player_score;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player_hp.health > 0)
        {
            player_score = (int)(player.transform.position.x - start_x);
            score2 = player_score;
        }
        if (player_score < 1000 && !playedEasy)
        {
            audiomanager.Stop("BGM_Theme");
            audiomanager.Play("BGM_Easy");
            playedEasy = true;
        }
        else if (1000 < player_score && player_score < 2000 && !playedMedium)
        {
            audiomanager.Stop("BGM_Easy");
            audiomanager.Play("BGM_Hard");
            playedMedium = true;
        }
        else if (2000 < player_score && playedHard)
        {
            audiomanager.Stop("BGM_Hard");
            audiomanager.Play("BGM_Extreme");
            playedHard = true;
        }
    }
    public int getScore()
    {
        return player_score;
    }
}

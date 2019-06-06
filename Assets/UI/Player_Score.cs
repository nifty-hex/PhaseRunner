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

    // Start is called before the first frame update
    void Start()
    {
        player_score = 0;
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
    }
}

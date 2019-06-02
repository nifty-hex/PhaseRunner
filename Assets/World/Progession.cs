using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progession : MonoBehaviour
{
    public Enemy_Spawn en_spawn;
    public Map_Generation map_gen;
    public Player_Score score;
    public int increase;
    int oldscore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score.score2 % increase == 0 && score.score2 != 0
            && score.score2 != oldscore)
        {
            oldscore = score.score2;
            print("Getting Harder");
        }
    }
}

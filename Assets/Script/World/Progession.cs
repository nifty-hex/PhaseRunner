using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progession : MonoBehaviour
{
    public Enemy_Spawn en_spawn;
    public Map_Generation map_gen;
    public Player_Score score;
    public Player_Move playermove;
    public Enemy_Spawn en_type;
    public Firewall firewall;

    private float spawn_ref = 2f;
    private int mt_cooldown = 5;
    private float faster_speed = 1f;

    public int increaseEveryXScore;
    int oldscore;

    // Update is called once per frame
    void Update()
    {
        if (score.score2 % increaseEveryXScore == 0 && score.score2 != 0
            && score.score2 != oldscore)
        {
            oldscore = score.score2;
            gettingHarder();
        }
    }
    void gettingHarder()
    {
        if (en_spawn.spawn_refresh_rate < 100)
            en_spawn.spawn_refresh_rate += spawn_ref;
        if (map_gen.obstacles_freq > 50)
            map_gen.obstacles_freq -= mt_cooldown;
        if (playermove.normal_speed_limit < 18)
        {
            playermove.high_speed_limit += faster_speed;
            playermove.low_speed_limit += faster_speed;
            playermove.normal_speed_limit += faster_speed;
            firewall.high_speed += faster_speed;
            firewall.low_speed += faster_speed;
        }
        if (en_type.spawn_type != 8)
            en_type.spawn_type++;
    }
}

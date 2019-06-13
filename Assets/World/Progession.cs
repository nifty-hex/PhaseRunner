using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progession : MonoBehaviour
{
    public Enemy_Spawn en_spawn;
    public Map_Generation map_gen;
    public Player_Score score;
    public Drop_Items dr_i;
    public Player_Move pl_m;
    public Enemy_Spawn en_type;

    public float spawn_ref = 10f;
    public int mt_cooldown = 10; //reduce for faste
    public int drop_plus = 5;
    public float faster_speed = 0.1f; //per frame

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
            Debug.Log("Getting Harder");
            gettingHarder();
        }
    }
    void gettingHarder()
    {
        en_spawn.max_enemy_num++;
        en_spawn.spawn_refresh_rate += spawn_ref;
        map_gen.obstacles_freq -= mt_cooldown;
        dr_i.drop_item_chance += drop_plus;
        pl_m.high_speed_limit += Time.deltaTime * faster_speed;
        pl_m.low_speed_limit += Time.deltaTime * faster_speed;
        pl_m.speed_limit += Time.deltaTime * faster_speed;
        if (en_type.spawn_type != 8)
            en_type.spawn_type++;
    }
}

using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayModeTests : MonoBehaviour
{

    public Meteor_Prefab meteor_script;
    // public Player_Prefab player_script; 

    [UnityTest]
    public IEnumerator testPlayerMovement()
    {
        GameObject player =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Player"));

        float distance1 = player.transform.position.x;
        yield return new WaitForSeconds(0.5f);
        float distance2 = player.transform.position.x;
        Assert.True(distance2 > distance1);
    }
    /*
    [UnityTest]
    public IEnumerator testPlayerSpeedBounds()
    {
        GameObject player =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Player"));

        player_script = player.GetComponent<Player_Prefab>(); // need to add player prefab
        Assert.True(player_script.low_speed_limit <= player_script.speed <= player_script.high_speed_limit);
    }
    */
    [UnityTest]
    public IEnumerator testSpawnPlayerBullet()
    {
        GameObject bullet =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Bullet"));

        yield return new WaitForSeconds(0.1f);
        Assert.IsNotNull(bullet);
    }

    [UnityTest]
    public IEnumerator testPlayerBulletMovement()
    {
        GameObject player =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Player"));

        GameObject bullet =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Bullet"));

      float distance1 = bullet.transform.position.x - player.transform.position.x;
      yield return new WaitForSeconds(0.5f);
      float distance2 = bullet.transform.position.x - player.transform.position.x;

      Assert.True(distance1 < distance2);
    }

    [UnityTest]
    public IEnumerator testEnemyBulletAimAtPlayer()
    {
        GameObject player =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Player"));

        GameObject enemy_bullet =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Common_Bullet"));


        float distance1 = enemy_bullet.transform.position.x - player.transform.position.x;
        yield return new WaitForSeconds(0.5f);
        float distance2 = enemy_bullet.transform.position.x - player.transform.position.x;

        Assert.True(distance1 > distance2);
    }

    [UnityTest]
    public IEnumerator testBulletHitObstacles()
    {
        GameObject bullet =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Bullet"));

        GameObject meteor =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Meteor"));

        meteor_script = meteor.GetComponent<Meteor_Prefab>();

        yield return new WaitForSeconds(0.5f);

        Assert.False(meteor_script.got_hit);
    }

}

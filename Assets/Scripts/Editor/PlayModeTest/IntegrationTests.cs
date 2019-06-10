using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class IntegrationTests : MonoBehaviour
{

    public Meteor_Prefab meteor_script;
    public Meteor_Prefab meteor_script2;
    public Health_Prefab player_health;

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

        Destroy(player);
        Destroy(bullet);
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

        Destroy(player);
        Destroy(enemy_bullet);
    }

    [UnityTest]
    public IEnumerator testBulletHitObstacles()
    {
        GameObject bullet1 =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Bullet2"), new Vector2(0, 0), Quaternion.identity);

        GameObject meteor1 =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Meteor"), new Vector2(100f, 100f), Quaternion.identity);

        GameObject bullet2 =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Bullet2"), new Vector2(0, 0), Quaternion.identity);

        GameObject meteor2 =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Meteor"), new Vector2(10.4f, 1.4f), Quaternion.identity);

        bullet1.GetComponent<CircleCollider2D>();
        meteor1.GetComponent<CircleCollider2D>();
        meteor_script = meteor1.GetComponent<Meteor_Prefab>();

        bullet2.GetComponent<CircleCollider2D>();
        meteor2.GetComponent<CircleCollider2D>();
        meteor_script2 = meteor2.GetComponent<Meteor_Prefab>();

        yield return new WaitForSeconds(0.5f);

        Assert.False(meteor_script.got_hit); //Distance from Bullet to Meteor is too far
        Assert.True(meteor_script2.got_hit); //Distance from Bullet to Meteor close enough to collide

        Destroy(bullet1);
        Destroy(bullet2);
        Destroy(meteor1);
        Destroy(meteor2);
    }

    [UnityTest]
    public IEnumerator testMeteorHitPlayer()
    {
        GameObject player =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Player"), new Vector3(0, 0, 0), Quaternion.identity);

        GameObject meteor =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Meteor"), new Vector3(0, 0, 0), Quaternion.identity);

        meteor_script = meteor.GetComponent<Meteor_Prefab>();
        player_health = player.GetComponent<Health_Prefab>();
        yield return new WaitForSeconds(0.5f);

        Assert.True(meteor_script.got_hit);
        Assert.True(player_health.health == 2);
    }
}


using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayModeTests : MonoBehaviour
{

    public Meteor_Prefab meteor_script;
    public Meteor_Prefab meteor_script2;
    public Jump_Prefab player_jump;
    public Slow_Prefab player_slow;
    public Shoot_Prefab player_shoot;
    public Player_Move player_script;
    public Bullet_Prefab bullet_script;
    public Health_Prefab player_health;

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
        Destroy(player);
    }
    
    [UnityTest]
    public IEnumerator testPlayerSpeedBounds()
    {
        GameObject player =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Player"));

        player_script = player.GetComponent<Player_Move>(); // need to add player prefab
        Assert.True(player_script.low_speed_limit <= player_script.speed_limit);
        Assert.True(player_script.speed_limit <= player_script.high_speed_limit);
        yield return new WaitForSeconds(0.1f);
        Destroy(player);
    }
    
    
    [UnityTest]
    public IEnumerator test_charger_movement()
    {
        GameObject charger =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Charger"));

        Assert.IsNotNull(charger);

        float position1 = charger.transform.position.x;
        yield return new WaitForSeconds(0.5f);
        float position2 = charger.transform.position.x;

        Assert.False(position1 == position2);
        Destroy(charger);
    }
    

    [UnityTest]
    public IEnumerator testSpawnPlayerBullet()
    {
        GameObject bullet =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Bullet"));

        yield return new WaitForSeconds(0.1f);
        Assert.IsNotNull(bullet);

        Destroy(bullet);
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
                ("Prefab/Bullet2"), new Vector2(0,0), Quaternion.identity);

        GameObject meteor2 =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Meteor"), new Vector2(10.4f,1.4f), Quaternion.identity);

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
    public IEnumerator testMeteorMovement()
    {
        GameObject meteor =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Meteor"));

        float distance1_x = meteor.transform.position.x;
        yield return new WaitForSeconds(0.5f);
        float distance2_x = meteor.transform.position.x;

        Assert.True(distance1_x == distance2_x);

        float distance1_y = meteor.transform.position.y;
        yield return new WaitForSeconds(0.5f);
        float distance2_y = meteor.transform.position.y;

        Assert.True(distance1_y > distance2_y);

        Destroy(meteor);
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

        Assert.True(player_health.health == 3);
        yield return new WaitForSeconds(0.5f);

        Assert.True(meteor_script.got_hit);
        Assert.True(player_health.health == 2);

        Destroy(player);
        Destroy(meteor);
    }

    //System Testing
    
    [UnityTest]
    public IEnumerator DoubleJump()
    {
        GameObject player =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Player_Jump"));

        player_jump = player.GetComponent<Jump_Prefab>();
        float current_height = player_jump.GetComponent<Rigidbody2D>().position.y;
        Assert.True(player_jump.jump_force > 0);
        Assert.True(player_jump.double_jump_force > 0);

        float height0 = current_height;
        float height1 = current_height;
        float height2 = current_height;

        //First Jump
        player_jump.jump();
        yield return new WaitForSeconds(0.2f);
        height1 = player_jump.GetComponent<Rigidbody2D>().position.y;

        //double Jump
        if (player_jump.did_jump)
        {
            player_jump.double_jump();
            yield return new WaitForSeconds(0.2f);
            height2 = player_jump.GetComponent<Rigidbody2D>().position.y;
        }

        Debug.Log("Height 0: " + height0);
        Debug.Log("Height 1: " + height1);
        Debug.Log("Height 2: " + height2);

        yield return new WaitForSeconds(0.5f);

        Assert.True(height1 > height0);
        Assert.True(height2 > height1);

        Destroy(player);
    }

    [UnityTest]
    public IEnumerator SlowTime()
    {
        //SceneManager.LoadScene(2);

        GameObject player =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Player_Stop"));

        player_slow = player.GetComponent<Slow_Prefab>();
        player_slow.lower_limit = 0.5f;
        player_slow.upper_limit = 1f;
        float tolerance = 0.2f;
        float delta;

        Assert.True(player_slow.time_slow_time == 1f);

        yield return new WaitForSeconds(0.5f);

        player_slow.slowDown();
        yield return new WaitForSeconds(1f);
        delta = Mathf.Abs(player_slow.time_slow_time - player_slow.lower_limit);
        Debug.Log("Slowing: " + delta);
        Assert.True(delta < tolerance);

        yield return new WaitForSeconds(0.5f);

        player_slow.fastUp();
        yield return new WaitForSeconds(1f);
        delta = Mathf.Abs(player_slow.time_slow_time - player_slow.upper_limit);
        Debug.Log("Fasting: " + delta);
        Assert.True(delta < tolerance);

        Destroy(player);
    }

    [UnityTest]
    public IEnumerator PlayerShoot()
    {
        GameObject player =
           MonoBehaviour.Instantiate(Resources.Load<GameObject>
               ("Prefab/Player_Shoot"));
        player_shoot = player.GetComponent<Shoot_Prefab>();
        player_shoot.bullet = Resources.Load<GameObject>("Prefab/Bullet");

        GameObject bullet1 = null;
        GameObject bullet2 = null;

        bullet1 = player_shoot.createBullet();
        bullet2 = player_shoot.createBullet();

        yield return new WaitForSeconds(0.5f);

        Assert.NotNull(bullet1);
        Assert.NotNull(bullet2);
        Assert.AreNotSame(bullet1, bullet2);

        Destroy(player);
        Destroy(bullet1);
        Destroy(bullet2);
    }
}


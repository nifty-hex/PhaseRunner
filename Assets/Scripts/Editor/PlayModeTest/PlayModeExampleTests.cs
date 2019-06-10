using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class SystemTests : MonoBehaviour
{
    public Jump_Prefab player_jump;
    public Slow_Prefab player_slow;
    public Shoot_Prefab player_shoot;
    
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
    }

    /*
    [UnityTest]
    public IEnumerator Framerate()
    {
        SceneManager.LoadScene(2);
        yield return new WaitForSeconds(0.5f);
        Debug.Log(Application.targetFrameRate);
        Assert.True(Application.targetFrameRate > 0);
    }
    */
}

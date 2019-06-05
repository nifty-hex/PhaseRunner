using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayModeTests : MonoBehaviour
{

    public Meteor_Prefab meteor_script;

    [UnityTest]
    public IEnumerator PlayerMovement()
    {
        GameObject player =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Player"));

        float distance1 = player.transform.position.x;
        yield return new WaitForSeconds(0.5f);
        float distance2 = player.transform.position.x;
        Assert.True(distance2 > distance1);
    }

    [UnityTest]
    public IEnumerator SpawnPlayerBullet()
    {
        GameObject gameGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Bullet"));

        Assert.True(true);
        yield return new WaitForSeconds(0.1f);
    }

    [UnityTest]
    public IEnumerator EnemyBulletAimAtPlayer()
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
    public IEnumerator BulletHitObstacles()
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

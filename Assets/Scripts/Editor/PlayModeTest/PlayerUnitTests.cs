using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayerUnitTests : MonoBehaviour
{
    public Player_Move player_script;

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

    /*[UnityTest]
    public IEnumerator testPlayerSpeedBounds()
    {
        GameObject player =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Player"));

        player_script = player.GetComponent<Player_Move>();
        Assert.True(player_script.low_speed_limit <= player_script.speed_limit);
        Assert.True(player_script.speed_limit <= player_script.high_speed_limit);
        yield return new WaitForSeconds(0.1f);
        Destroy(player);
    }*/
}
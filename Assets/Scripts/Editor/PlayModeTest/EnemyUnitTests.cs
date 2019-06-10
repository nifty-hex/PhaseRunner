using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class EnemyUnitTests : MonoBehaviour
{

    Common_Enemy_Prefab enemy_script;

    [UnityTest]
    public IEnumerator testChargerMovement()
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
    public IEnumerator test_common_enemy_detect_player()
    {
        GameObject enemy =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Common_Enemy"));

        GameObject player =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>
                ("Prefab/Player"));

        Assert.IsNotNull(enemy);
        Assert.IsNotNull(player);

        enemy_script = enemy.GetComponent<Common_Enemy_Prefab>();
        Assert.IsNotNull(enemy_script.player);

        yield return new WaitForSeconds(0.5f);

        Destroy(enemy);
        Destroy(player);
    }
}

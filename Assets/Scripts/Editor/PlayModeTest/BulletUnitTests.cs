using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class BulletUnitTests : MonoBehaviour
{
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
}

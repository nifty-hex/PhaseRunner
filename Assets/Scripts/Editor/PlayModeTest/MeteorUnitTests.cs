using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MeteorUnitTests : MonoBehaviour
{
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
}

using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ChargerUnitTests : MonoBehaviour
{
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
}

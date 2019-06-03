using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using NUnit.Framework;
using System.Collections;

public class PlayModeTests{
    
    private Camera main_cam;
    public GameObject bullet;
    public GameObject Main_Camera;

    [Test]
    public void PlayModeTestsSimplePasses() {
        Assert.True(true);
    }


    [UnityTest]
    public IEnumerator PlayModeTestsWithEnumeratorPasses() {
        
        Assert.True(true);
        yield return null;
        Assert.True(true);
    }


    [UnityTest]
    public IEnumerator Bullet_Moves()
    {
        var en_spawn = GameObject.Find("Main Camera").GetComponent<Enemy_Spawn>();

        var BulletPrefab = GameObject.FindWithTag("Player_Bullet");
        var PrefabOfSpawnedBullet = PrefabUtility.GetPrefabParent(BulletPrefab);

        Assert.AreEqual(BulletPrefab, PrefabOfSpawnedBullet);
        yield return new WaitForSeconds(0.1f);
        Assert.True(true);
    }
}

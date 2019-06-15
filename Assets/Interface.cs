using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKillable
    // Start is called before the first frame update
 {
    void Kill();
 }

    // Update is called once per frame
public interface IDamageable<T>
{
    void Damage(T damageTaken);
}
public interface IDropable
{
    void DropItem();
}

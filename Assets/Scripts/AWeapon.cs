using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AWeapon : MonoBehaviour
{
    public abstract void FireBullet(Vector2 dir, Health.EFlag flag);
}

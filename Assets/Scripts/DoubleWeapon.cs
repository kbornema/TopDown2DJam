using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleWeapon : AWeapon
{
    [SerializeField]
    private AWeapon _a = default;
    [SerializeField]
    private AWeapon _b = default;

    public override void FireBullet(Vector2 dir, Health.EFlag flag)
    {
        _a?.FireBullet(dir, flag);
        _b?.FireBullet(dir, flag);
    }
}

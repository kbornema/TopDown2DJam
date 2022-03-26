using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    [SerializeField]
    private AWeapon _weapon = default;

    private void Update()
    {
        var player = Player.Instance;

        if (player != null)
        {
            var dir = player.transform.position - transform.position;
            dir.Normalize();

            if (player != null)
            {
                _weapon.FireBullet(dir, Health.EFlag.Enemy);
            }

            if (dir.sqrMagnitude != 0.0f)
            {
                SetDirection(dir);
            }
        }
    }
}

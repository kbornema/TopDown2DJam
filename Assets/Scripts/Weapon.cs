using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : AWeapon
{
    [SerializeField]
    private GameObject _bulletPrefab = default;

    [SerializeField]
    private int _minProjectiles = 1;
    [SerializeField]
    private int _maxProjectiles = 1;

    [SerializeField, Range(0.0f, 360.0f)]
    private float _spreadMin = 0.0f;
    [SerializeField, Range(0.0f, 360.0f)]
    private float _spreadMax = 0.0f;

    [SerializeField]
    private float _speedScaleMin = 1.0f;
    [SerializeField]
    private float _speedScaleMax = 1.0f;

    [SerializeField]
    private float _bulletCooldown = 1.0f;

    [SerializeField]
    private List<AudioClip> _clips = default;

    private float _curBulletCd;

    private void Awake()
    {
        _curBulletCd = _bulletCooldown;
    }

    private void Update()
    {
        _curBulletCd -= Time.deltaTime;
    }

    public override void FireBullet(Vector2 dir, Health.EFlag flag)
    {
        if (_curBulletCd <= 0.0f)
        {
            _curBulletCd = _bulletCooldown;

            int projectiles = UnityEngine.Random.Range(_minProjectiles, _maxProjectiles + 1);

            Sound.Play(_clips);

            for (int i = 0; i < projectiles; i++)
            {
                float spread = UnityEngine.Random.Range(_spreadMin, _spreadMax);

                float curSpread = UnityEngine.Random.Range(spread * -0.5f, spread * 0.5f);

                var rotation = Quaternion.Euler(0.0f, 0.0f, curSpread);
                var newdir = rotation * dir;

                float speedScale = UnityEngine.Random.Range(_speedScaleMin, _speedScaleMax);

                var bullet = GameObject.Instantiate(_bulletPrefab, transform.position, Quaternion.identity);

                var projectile = bullet.GetComponent<Projectile>();

                if (projectile != null)
                {
                    projectile.SetSpeedScale(speedScale);
                    projectile.SetDirection(newdir);
                    projectile.SetFlag(flag);
                }
            }
        }
    }
}

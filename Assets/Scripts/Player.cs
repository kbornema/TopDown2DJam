using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    public static Player Instance;

    [SerializeField]
    private float _healthDrain = 1.0f;
    [SerializeField]
    private AWeapon _weapon0 = default;
    [SerializeField]
    private AWeapon _weapon1 = default;

    [SerializeField]
    private GUI_Highscore _highscore = default;

    private Camera _camera = default;

    private int _points = default;

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();

        if (_health.CurHealth > 0.0f)
        {
            _health.ChangeHealth(-_healthDrain * Time.deltaTime);

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            SetDirection(new Vector2(x, y));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(Input.GetMouseButton(0))
        {
            TryFire(_weapon0);
        }

        if (Input.GetMouseButton(1))
        {
            TryFire(_weapon1);
        }
    }

    private void TryFire(AWeapon w)
    {
        if (w != null)
        {
            if (_camera == null)
            {
                _camera = Camera.main;
            }

            var worldMousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            var dir = worldMousePos - transform.position;
            dir.z = 0.0f;
            dir.Normalize();

            w.FireBullet(dir, Health.EFlag.Player);
        }
    }

    public int GetPoint()
    {
        return _points;
    }

    public void AddPoints(int points)
    {
        _points += points;

        if (_highscore != null)
        {
            _highscore.SetPoints(_points);
        }
    }
}

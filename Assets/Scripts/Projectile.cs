using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public enum EWaveStyle { None, Sin, Cos }

    [SerializeField]
    private float _speed = 15.0f;
    [SerializeField]
    private float _damage = 1.0f;
    [SerializeField]
    private float _lifeTime = 10.0f;

    [SerializeField]
    private float _sinusScale = 0.0f;
    [SerializeField]
    private float _sinusSpeed = 0.0f;
    [SerializeField, Range(0.0f, 1.0f)]
    private float _sinusOffset = 0.0f;

    private float _sinusTime;
    [SerializeField]
    private EWaveStyle _waveStyle = default;

    private Vector2 _direction;

    private Health.EFlag _flag = Health.EFlag.Enemy;

    private void Update()
    {
        var pos = (Vector2)transform.position;

        var curDir = _direction * _speed;

        if(_sinusScale != 0.0f && _waveStyle != EWaveStyle.None)
        {
            _sinusTime += Time.deltaTime;

            float trig = 0.0f;
 
            switch (_waveStyle)
            {
                case EWaveStyle.Sin:
                    trig = Mathf.Sin(_sinusOffset * Mathf.PI * 2.0f + _sinusTime * _sinusSpeed);
                    break;
                case EWaveStyle.Cos:
                    trig = Mathf.Cos(_sinusOffset * Mathf.PI * 2.0f + _sinusTime * _sinusSpeed) * -1.0f;
                    break;
                default:
                    break;
            }

            var ortho = new Vector2(_direction.y, -_direction.x) * trig * _sinusScale;
            curDir += ortho;
        }

        pos += curDir * Time.deltaTime;
        transform.position = pos;

        _lifeTime -= Time.deltaTime;

        if(_lifeTime <= 0.0f)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public void SetSpeedScale(float scale)
    {
        _speed *= scale;
    }

    public void SetDirection(Vector2 dir)
    {
        _direction = dir;
    }

    public void SetFlag(Health.EFlag flag)
    {
        _flag = flag;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<Health>();

        if(health != null && health.Flag != _flag)
        {
            health.ChangeHealth(-_damage);
            GameObject.Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Collider"))
        {
            GameObject.Destroy(gameObject);
        }
    }
}

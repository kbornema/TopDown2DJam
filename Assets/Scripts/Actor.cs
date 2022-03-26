using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField]
    protected Health _health = default;
    public Health GetHealth() => _health;

    [SerializeField]
    private float _movementSpeed = 1.0f;

    private Vector2 _direction;

    private List<SpeedChange> _speedChanges = new List<SpeedChange>();

    protected virtual void Awake()
    {

    }

    protected virtual void LateUpdate()
    {
        float speedFactor = 1.0f;

        for (int i = 0; i < _speedChanges.Count; i++)
        {
            var speedChange = _speedChanges[i];

            if (speedChange.Time <= 0.0f)
            {
                _speedChanges.RemoveAt(i);
                i--;
            }
            else
            {
                speedChange.Time -= Time.deltaTime;
                speedFactor *= speedChange.Delta;
            }
        }

        var curMoveSpeed = _movementSpeed * speedFactor;

        if (curMoveSpeed < 0.0f)
        {
            curMoveSpeed = 0.0f;
        }

        var pos = (Vector2)transform.position;
        pos += _direction * curMoveSpeed * Time.deltaTime;
        transform.position = pos;
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void AddSpeedChange(float delta, float time)
    {
        _speedChanges.Add(new SpeedChange(delta, time));
    }

    public class SpeedChange
    {
        public float Delta;
        public float Time;

        public SpeedChange(float delta, float time)
        {
            Delta = delta;
            Time = time;
        }
    }
}

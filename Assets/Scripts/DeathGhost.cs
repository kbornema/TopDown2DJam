using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGhost : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _lifeTime = 4.0f;

    private void Update()
    {
        var pos = transform.position;
        pos.y += _speed * Time.deltaTime;
        transform.position = pos;

        _lifeTime -= Time.deltaTime;

        if(_lifeTime <= 0.0f)
        {
            GameObject.Destroy(gameObject);
        }
    }
}

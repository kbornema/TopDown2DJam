using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField]
    private float _healthPerSecond = 5.0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();

        if(health != null && health.Flag == Health.EFlag.Player)
        {
            health.ChangeHealth(_healthPerSecond * Time.fixedDeltaTime);
        }
    }
}

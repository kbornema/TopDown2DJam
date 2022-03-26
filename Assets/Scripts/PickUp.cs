using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField, Range(0.0f, 1.0f)]
    private float _slowDown = 5.0f;
    [SerializeField]
    private float _duration = 5.0f;

    [SerializeField]
    private GameObject _root = default;
    [SerializeField]
    private GameObject _prefab = default;

    [SerializeField]
    private List<AudioClip> _sfxs = default;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();

        if(health != null)
        {
            var pos = transform.position;
            GameObject.Instantiate(_prefab, pos, Quaternion.identity);
            WorldText.CreateText("Yay!", pos);

            var actor = health.GetOwner();
            actor.AddSpeedChange(_slowDown, _duration);

            Sound.Play(_sfxs);

            GameObject.Destroy(_root);
        }
    }
}

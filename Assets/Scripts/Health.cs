using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public enum EFlag { Player, Enemy }

    [SerializeField]
    private int _points = 5;

    [SerializeField]
    private Actor _owner = default;
    public Actor GetOwner() => _owner;

    [SerializeField]
    private GameObject _root = default;
    [SerializeField]
    private GameObject _deathPrefab = default;
    [SerializeField]
    private float _maxHealth = 100.0f;

    [SerializeField]
    private EFlag _flag = EFlag.Enemy;
    public EFlag Flag => _flag;

    private float _curHealth;
    public float CurHealth => _curHealth;

    public float GetPercent() => _curHealth / _maxHealth;

    private bool _isDead = false;

    [SerializeField]
    private List<AudioClip> _hitSfx = default;

    private void Awake()
    {
        _curHealth = _maxHealth;
    }

    public void ChangeHealth(float delta)
    {
        _curHealth = _curHealth + delta;

        if (_curHealth <= 0.0f && !_isDead)
        {
            _isDead = true;
            _curHealth = 0.0f;

            if(_flag == EFlag.Enemy)
            {
                Player.Instance.AddPoints(_points);
            }

            GameObject.Destroy(_root);
            GameObject.Instantiate(_deathPrefab, transform.position, Quaternion.identity);

            if(_flag == EFlag.Player)
            {
                SceneManager.LoadScene("Scene_GameOver");
            }
        }
        else if(_curHealth >= _maxHealth)
        {
            _curHealth = _maxHealth;
        }

        if(_isDead && _curHealth > 0.0f)
        {
            _isDead = false;
        }

        if(!_isDead && delta < 0.0f && Mathf.Abs(delta) > 2.0f)
        {
            Sound.Play(_hitSfx);
        }
    }
}

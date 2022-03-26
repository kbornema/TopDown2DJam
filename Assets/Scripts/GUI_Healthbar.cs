using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Healthbar : MonoBehaviour
{
    [SerializeField]
    private Image _fill = default;
    [SerializeField]
    private Health _health = default;

    public void SetHealth(Health health)
    {
        _health = health;
    }
    
    private void Update()
    {
        if (_health != null)
        {
            float t = _health.GetPercent();
            _fill.fillAmount = t;
        }
        else
        {
            _fill.fillAmount = 0.0f;
            GameObject.Destroy(gameObject);
        }
    }
}

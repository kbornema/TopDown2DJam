using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldText : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI _text = default;
    [SerializeField]
    private float _durationFactor = 1.0f;

    private float _time = 0.0f;

    private void Update()
    {
        _time -= Time.deltaTime;

        if(_time <= 0.0f)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public void SetText(string text)
    {
        _text.text = text;
    }

    public static WorldText CreateText(string text, Vector2 pos)
    {
        var worldText = Resources.Load<WorldText>("WorldText");
        var instance = GameObject.Instantiate(worldText, pos, Quaternion.identity);
        instance.SetText(text);
        instance._time = text.Length * instance._durationFactor;
        return instance;
    }
}

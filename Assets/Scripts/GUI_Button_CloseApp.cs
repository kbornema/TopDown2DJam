using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Button_CloseApp : MonoBehaviour
{
    [SerializeField]
    private Button _button = default;

    private void Start()
    {
        _button.onClick.AddListener(OnClickListener);
    }

    private void OnClickListener()
    {
        Application.Quit();
    }
}

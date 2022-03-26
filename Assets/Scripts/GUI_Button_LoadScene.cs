using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUI_Button_LoadScene : MonoBehaviour
{
    [SerializeField]
    private string _sceneName = default;
    [SerializeField]
    private Button _button = default;

    private void Start()
    {
        _button.onClick.AddListener(OnClickListener);
    }

    private void OnClickListener()
    {
        SceneManager.LoadScene(_sceneName);
    }
}

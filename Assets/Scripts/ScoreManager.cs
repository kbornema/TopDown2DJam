using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private List<SpawnCentral> _spawners = default;
    [SerializeField]
    private int _scoreLimit = 100;
    [SerializeField]
    private string _nextSceneName = default;

    private bool _hasFinished = false;

    private void Update()
    {
        if(Player.Instance != null)
        {
            if(Player.Instance.GetPoint() >= _scoreLimit)
            {
                if (!_hasFinished)
                {
                    _hasFinished = true;
                    StartCoroutine(SceneRoutine());
                }
            }
        }
    }

    private IEnumerator SceneRoutine()
    {
        for (int i = 0; i < _spawners.Count; i++)
        {
            _spawners[i].Stop();
        }

        yield return new WaitForSeconds(5.0f);


        SceneManager.LoadScene(_nextSceneName);

    }
}

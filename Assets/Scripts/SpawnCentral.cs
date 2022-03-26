using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCentral : MonoBehaviour
{
    [SerializeField]
    private List<SpawnPoint> _points = default;
    [SerializeField]
    private List<GameObject> _prefabs = default;
    [SerializeField]
    private float _spawnCdMin = 5.0f;
    [SerializeField]
    private float _spawnCdMax = 5.0f;

    [SerializeField]
    private int _minSpawns = 1;
    [SerializeField]
    private int _maxSpawns = 3;

    [SerializeField]
    private int _aliveLimit = 4;

    private float _curSpawnCd = default;

    [SerializeField]
    private List<GameObject> _instances = new List<GameObject>();

    private void Awake()
    {
        _curSpawnCd = _spawnCdMax;
    }

    private void Update()
    {
        _curSpawnCd -= Time.deltaTime;
        
        if(_curSpawnCd <= 0.0f)
        {
            var currentAlive = CalcCurrentAlive();

            if(currentAlive == -1 || currentAlive < _aliveLimit)
            {
                Spawn();
            }
        }
    }

    public void Stop()
    {
        enabled = false;

        for (int i = 0; i < _instances.Count; i++)
        {
            var inst = _instances[i];
            GameObject.Destroy(inst);
        }

        _instances.Clear();
    }

    private int CalcCurrentAlive()
    {
        _instances.RemoveAll(x => x == null);
        return _instances.Count;
    }

    private void Spawn()
    {
        int numSpawns = UnityEngine.Random.Range(_minSpawns, _maxSpawns + 1);

        for (int i = 0; i < numSpawns; i++)
        {
            _curSpawnCd = UnityEngine.Random.Range(_spawnCdMin, _spawnCdMax);
            var point = GetRandomPoint();

            if (point != null)
            {
                var prefab = GetRandomPrefab();
                var instance = GameObject.Instantiate(prefab, point.transform.position, Quaternion.identity);
                _instances.Add(instance);
            }
        }
    }

    private GameObject GetRandomPrefab()
    {
        var point = _prefabs[UnityEngine.Random.Range(0, _prefabs.Count)];
        return point;
    }

    private SpawnPoint GetRandomPoint()
    {
        var point = _points[UnityEngine.Random.Range(0, _points.Count)];
        return point;
    }
}

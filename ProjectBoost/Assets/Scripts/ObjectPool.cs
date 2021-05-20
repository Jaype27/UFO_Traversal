using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject[] _prefab;
    [SerializeField] [Range(0.1f, 5f)] float _spawnTimer;
    [SerializeField] bool _isSpawning;
    [SerializeField] [Range(0, 50)] int _poolSize;

    GameObject[] _pool;

    void Awake() {
        PopulatePool();
    }

    void Start() {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool() {
        _pool = new GameObject[_poolSize]; 

        for(int i = 0; i < _pool.Length; i++) {
            _pool[i] = Instantiate(_prefab[Random.Range(0, _prefab.Length)], transform);
            _pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool() {
        for(int i = 0; i < _pool.Length; i++) {
            if(_pool[i].activeInHierarchy == false) {
                _pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy() {
        while(_isSpawning) {
            EnableObjectInPool();
            yield return new WaitForSeconds(_spawnTimer);
        }
    }
}

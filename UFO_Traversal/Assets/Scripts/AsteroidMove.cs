using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float minY = 0f;
    [SerializeField] float maxY = 30f;
    ObjectPool _objectPool;

    
    void Awake() {
        _objectPool = FindObjectOfType<ObjectPool>();
    }
    
    void OnEnable() {
        float PosY = Random.Range(minY, maxY);
        Vector3 temp = _objectPool.transform.position;
        temp.y = PosY;

        transform.position = temp;
    }
    
    void Update() {
        transform.Translate(Vector3.left * Time.deltaTime * _moveSpeed);
    }

    void OnTriggerEnter(Collider other) {
        gameObject.SetActive(false);
    }


    
}

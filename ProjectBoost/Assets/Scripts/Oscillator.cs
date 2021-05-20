using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    Vector3 _startingPosition;
    [SerializeField] Vector3 _movementVector;
    float _movementFactor;

    [SerializeField] float _period = 2f;

    // Start is called before the first frame update
    void Start() {
        _startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {

        if(_period <= Mathf.Epsilon) { return; }


        float cycles = Time.time / _period; // continually growing over time
        
        const float tau = Mathf.PI * 2; // constant calue of 6.28
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

        _movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1 so its clearer

        Vector3 offset = _movementVector * _movementFactor;

        transform.position = _startingPosition + offset;


    }
}

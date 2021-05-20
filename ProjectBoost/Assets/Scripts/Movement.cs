using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float _thrustPower = 1000f;
    [SerializeField] float _rotateSpeed = 10f;

    [SerializeField] AudioClip _shipThrusters;

    [SerializeField] ParticleSystem _mainThrustParticles;
    [SerializeField] ParticleSystem _leftThrustParticles;
    [SerializeField] ParticleSystem _rightThrustParticles;
    
    Rigidbody _rb;
    AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() {

        if(Input.GetKey(KeyCode.Space)) {
            StartThrusting();
        }
        else {
            StopThrusting();
        }
    }


    void ProcessRotation() {
        if(Input.GetKey(KeyCode.A)) {
            RotateLeft();

        }
        else if(Input.GetKey(KeyCode.D)) {
            RotateRight();

        }
        else {
            StopRotate();
        }
    }



    void StartThrusting() {
        _rb.AddRelativeForce(Vector3.up * _thrustPower * Time.deltaTime);

        if (!_audio.isPlaying) {
            _audio.PlayOneShot(_shipThrusters);
        }

        if (!_mainThrustParticles.isPlaying) {
            _mainThrustParticles.Play();
        }
    }

    void StopThrusting() {
        _audio.Stop();
        _mainThrustParticles.Stop();
    }

    

    

    void RotateRight() {
        ApplyRotation(-_rotateSpeed);

        if (!_leftThrustParticles.isPlaying) {
            _leftThrustParticles.Play();
        }
    }

    void RotateLeft() {
        ApplyRotation(_rotateSpeed);

        if (!_rightThrustParticles.isPlaying) {
            _rightThrustParticles.Play();
        }
    }

    void StopRotate() {
        _leftThrustParticles.Stop();
        _rightThrustParticles.Stop();
    }

    void ApplyRotation(float rotationThisFrame) {
        _rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        _rb.freezeRotation = false;
    }
}

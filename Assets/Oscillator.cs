﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;

    // ToDo: remove form inspector later 
    [Range(0,1)]
    float movementFactor;


    Vector3 startingPos;


    // Start is called before the first frame update
    void Start(){
        startingPos = transform.position;    
    }

    // Update is called once per frame
    void Update(){
        float cycles = Time.time / period; 
        const float tau = Mathf.PI * 2; // about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau);
        print(rawSinWave);

        movementFactor = (rawSinWave / 2f) + 0.5f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}

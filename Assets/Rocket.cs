using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour{
    Rigidbody rigidBody;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start(){
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        ProcessInput();
    }

    private void ProcessInput(){
        if(Input.GetKey(KeyCode.Space)){
            // adds force to make rocket go up
            rigidBody.AddRelativeForce(Vector3.up);

            // so audio doesnt play
            if(! audioSource.isPlaying){
                audioSource.Play();
            }
        }

        else{
            audioSource.Stop();
        }
        
        // rotate the ship left or right
        if(Input.GetKey(KeyCode.A)){
            // print("rotate left");
            transform.Rotate(Vector3.forward);
        }
        
        else if(Input.GetKey(KeyCode.D)){
            // print("rotate right");
             transform.Rotate(-Vector3.forward);
        }
    }
}
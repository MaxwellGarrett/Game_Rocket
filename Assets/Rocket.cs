using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour{
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    
    Rigidbody rigidBody;
    AudioSource audioSource;

    enum State { Alive, Dying, Transcending }
    State state = State.Alive;

    // Start is called before the first frame update
    void Start(){
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        if (state == State.Alive){
            // only rotate and thrust when alive
            Rotate();
            Thrust();
        }
    }

    private void Rotate(){
        
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        // freeze rotation to take manual control
        rigidBody.freezeRotation = true;
        // rotate the ship left or right
        if(Input.GetKey(KeyCode.A)){
            // rotating left about the z-axis
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        
        else if(Input.GetKey(KeyCode.D)){
            // rotating right about the z-axis
             transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        // resume physics control  
        rigidBody.freezeRotation = false;
    }

    void OnCollisionEnter(Collision collision){
        if (state != State.Alive){
            return;
        }
        switch (collision.gameObject.tag) {
            case "Friendly":
               print("Excellent");
               break;
               
            case "Finish":
               state = State.Transcending;
               Invoke("LandNextScene", 1f);
               break;

            default:
                print("Deadly");
                SceneManager.LoadScene(0);
                break; 
        }
    }

    private void Thrust(){
        if (Input.GetKey(KeyCode.Space)){
            // adds force to make rocket go up
            rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }

            // so audio doesnt play
            if(! audioSource.isPlaying){
                audioSource.Play();
            }

            else {
                audioSource.Stop();
            }
        }


        private void LandNextScene(){
            // todo: allow for more then 2 level 
            SceneManager.LoadScene(1);
        }
} 
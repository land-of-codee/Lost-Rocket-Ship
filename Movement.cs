using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
 Rigidbody rb;
 AudioSource audioSource;
 [SerializeField] float mainThrust = 100f;
 [SerializeField] float rotationThrust = 1f;
[SerializeField] AudioClip mainEngine;

 [SerializeField] ParticleSystem mainEngineParticles;
[SerializeField] ParticleSystem leftThrusterParticles;
[SerializeField] ParticleSystem rightThrusterParticles;


    // Start is called before the first frame update
    void Start()
    {
         rb =  GetComponent<Rigidbody>(); 
         audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      
        ProcessRotation();
        ProcessThrust();
        
    }

    
    void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();

        }

        else
        {
            StopThrusting();
        }
    }

       void ProcessRotation()
    {
          if(Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }

        else if(Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }

        else
        {
            StopRotating();
        }
    }


    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }

        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }

 private void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }

 private void RotateLeft()
    {
        ApplyRotation(rotationThrust);
        if (!rightThrusterParticles.isPlaying)
        {
            rightThrusterParticles.Play();
        }
    }

     private void RotateRight()
    {
        ApplyRotation(-rotationThrust);
        if (!leftThrusterParticles.isPlaying)
        {
            leftThrusterParticles.Play();
        }
    }
    
    private void StopRotating()
    {
        rightThrusterParticles.Stop();
        leftThrusterParticles.Stop();
    }

     private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //Freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation so the physics system can take over
    }
}



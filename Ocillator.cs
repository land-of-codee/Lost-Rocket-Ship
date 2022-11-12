using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocillator : MonoBehaviour
{
    Vector3 startingPosition;
     [SerializeField] Vector3 movementVector;
     [SerializeField] [Range (0,1)]  float movementFactor; //The range is there to create a
                                                          //slider from 0-1. 
     [SerializeField] float period = 2f;
     
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        Debug.Log(startingPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if(period == Mathf.Epsilon ){return; }
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2; 
        float rawSinWave = Mathf.Sin(cycles * tau); //This will give a value from 1 to -1
        
        movementFactor = (rawSinWave + 1f) / 2; 

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset; 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform lookAt; //for get player transform.position
    private Vector3 offset; //To maintain a distance between the camera and player

    public Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 3.0f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);
    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform; 
        offset = transform.position - lookAt.transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
        moveVector = lookAt.position + offset;
        // make X value always zero
        moveVector.x = 0;

       
        if (transition > 1)
        {
            transform.position = moveVector;  //camera follow the player
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumkingS : MonoBehaviour
{
    public AudioSource pumkingSound;
    // Start is called before the first frame update
    void Start()
    {
        pumkingSound.PlayDelayed(3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

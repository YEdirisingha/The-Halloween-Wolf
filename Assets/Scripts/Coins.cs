using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private float coinRotateSpeed = 80.0f;

    public AudioClip coinCollectSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, coinRotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.coinsCount += 1;
            AudioSource.PlayClipAtPoint(coinCollectSound, transform.position, 0.1f);
            Destroy(gameObject); 
        }
    }

}

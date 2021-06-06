using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEnemy : MonoBehaviour
{
    // audio    
    AudioSource audioSource;
    public AudioClip destroy;
    public float volume = 0.2f; // volume

    private void Start() {
        // destroys object after 3 seconds
        Destroy(gameObject, 3);

        // find auto source
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("EnemyShip")) {        
            Destroy(collision.gameObject);   
            // destroy self 
            Destroy(gameObject);
            // to play sound
            audioSource.PlayOneShot(destroy, volume);
        }
    }
}

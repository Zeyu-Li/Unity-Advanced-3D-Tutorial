using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseCondition : MonoBehaviour
{
    public GameObject loseUI;
    // audio    
    public AudioSource audioSource;
    public AudioClip dies;
    public float volume = 0.2f; // volume

    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("EnemyShip")) {        
            Destroy(collision.gameObject);   
            // opens restart UI
            loseUI.SetActive(true);
            loseUI.GetComponent<restartShooter>().end();
            // to play sound
            audioSource.PlayOneShot(dies, volume);
        }
    }
}

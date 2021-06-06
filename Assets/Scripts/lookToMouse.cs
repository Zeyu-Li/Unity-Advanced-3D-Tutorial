using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookToMouse : MonoBehaviour
{
    // audio    
    public AudioSource audioSource;
    public AudioClip shootingSound;
    public float volume = 0.2f; // volume
    public float bulletSpeed = 20f; 

    private Vector2 shootDir;

    // from https://answers.unity.com/questions/855976/make-a-player-model-rotate-towards-mouse-location.html
    // Update is called once per frame
    void Update() {
        // Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        
        // Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        
        // Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        Quaternion unityAngle = Quaternion.Euler(new Vector3(0f,0f,angle+90));

        if (Input.GetButtonDown("Fire1")) {
            // create new object
            GameObject bullet = (GameObject)Instantiate(Resources.Load("Prefabs/playerProjectile"));
            // to play sound
            audioSource.PlayOneShot(shootingSound, volume);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = unityAngle;

            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
        }

        // set rotation of ship
        transform.rotation = unityAngle;
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}

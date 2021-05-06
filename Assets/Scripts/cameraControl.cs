using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    // sensitivety of mouse
    public float mouseSpeed = 100f;
    public float clampSize = 70f;

    // place camera here
    public Transform player;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        // for every frame, move camera up or down
        xRotation -= mouseY;
        // clamp the up down rotation
        xRotation = Mathf.Clamp(xRotation, -clampSize, clampSize); // clamp so it can't see itself

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onStart : MonoBehaviour
{
    public GameObject flashlightObject;
    public GameObject playerFlashlight;
    public GameObject player;
    public Animator openDoorAnimation;

    void Start()
    {
        if (PlayerPrefs.GetString("flashlight") == "") {
            PlayerPrefs.SetString("flashlight", "false");
        } else if (PlayerPrefs.GetString("flashlight") == "true") {
            // set flashlight enabled and remove flashlight object
            flashlightObject.SetActive(false);
            playerFlashlight.SetActive(true);
        }

        // set postion of player
        if (PlayerPrefs.GetInt("position") == 0) {
            // set start position if int is 0
            player.transform.position = new Vector3(4.294f, 2.422f, -15.366f);
        }

        // win condition
        if (PlayerPrefs.GetInt("win") == 1) {
            // open door
            openDoorAnimation.SetBool("doorOpen", true);
        }

    }
}

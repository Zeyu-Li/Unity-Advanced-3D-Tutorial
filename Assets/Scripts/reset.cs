using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // reset everything
        PlayerPrefs.SetString("flashlight", "");
        PlayerPrefs.SetInt("position", 0);
        PlayerPrefs.SetInt("win", 0);
        PlayerPrefs.SetString("dialog", "");
        PlayerPrefs.SetString("screenDialog", "");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enter2d : MonoBehaviour
{
    public string newScene;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            Time.timeScale = 1f;
            PlayerPrefs.SetInt("position", 1);
            SceneManager.LoadScene(newScene);
        }
    }
}

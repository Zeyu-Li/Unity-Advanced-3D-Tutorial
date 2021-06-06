using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterToNewScene : MonoBehaviour
{
    public string newScene;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            Time.timeScale = 1f;
            SceneManager.LoadScene(newScene);
        }
    }
}

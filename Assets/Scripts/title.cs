using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{
    // Start is called before the first frame update
    public void play() {
        SceneManager.LoadScene("Main");
    }

    public void quit() {
        Application.Quit();
    }

}
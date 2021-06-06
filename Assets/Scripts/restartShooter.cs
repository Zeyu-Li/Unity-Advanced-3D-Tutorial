using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartShooter : MonoBehaviour
{
    public GameObject ship;
    public GameObject self;

    public void end() {
        ship.SetActive(false);
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            // refresh
            ship.SetActive(true);
            Time.timeScale = 1f;
            ship.GetComponent<spawnEnemy>().restart();

            self.SetActive(false);
        }
    }
}

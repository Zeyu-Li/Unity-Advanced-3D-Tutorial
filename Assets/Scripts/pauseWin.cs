using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseWin : MonoBehaviour
{
    public GameObject ship;
    // Start is called before the first frame update
    void Start()
    {
        ship.SetActive(false);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

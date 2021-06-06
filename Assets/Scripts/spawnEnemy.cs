using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public float time = 30f;
    public int shipsCount = 27;
    [Header("The randomness in the x postion when spawn")]
    public float x = 4.5f;
    
    [Header("Height of screen")]
    public float y = 10f;

    public GameObject endScreen;

    private bool spawned = false;


    void Start()
    {
        StartCoroutine("Spawn");
    }

    public void restart() {
        StopCoroutine("Spawn");
        StartCoroutine("Spawn");
    }

    void Update() {
        // this check is squeezed till one is greater than the other (2.5 seconds for the last one to travel across the screen)
        if (spawned) {
            // show end message
            endScreen.SetActive(true);
        }
    }

    // Update is called once per frame
    IEnumerator Spawn() {
        for (int i = 0; i < shipsCount; i++) {
            // spawn enemy ship
            float randomX = Random.Range(-x, x);

            float spawnX = transform.position.x + randomX; 
            float spawnY = transform.position.y + y;

            // create new object
            GameObject enemyShip = (GameObject)Instantiate(Resources.Load("Prefabs/enemy"));
            enemyShip.transform.position = new Vector3(spawnX, spawnY, transform.position.z);
            
            // destroys object after 3 seconds
            Destroy(enemyShip, 3);

            // randomness
            if (i == shipsCount - 1) spawned = true;
            yield return new WaitForSeconds(time/shipsCount + Random.Range(-1 * (time/shipsCount) * 0.5f, 0));
        }
    }
}

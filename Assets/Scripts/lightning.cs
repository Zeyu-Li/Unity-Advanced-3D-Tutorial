using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour
{
    public Light lightningLight;
    public float minFlickerTime = 0.1f;
    public float maxFlickerTime = 0.4f;

    void Start() {
        lightningLight = GetComponent<Light>();
        lightningLight.enabled = false;
        StartCoroutine("Flicker");
    }

    IEnumerator Flicker() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(0.4f, 3f));
            lightningLight.enabled = true;
            yield return new WaitForSeconds(Random.Range(minFlickerTime, maxFlickerTime));
            lightningLight.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog : MonoBehaviour
{
    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject dialog3;
    public GameObject dialog5;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("dialog") == "") StartCoroutine("Dialog");

        if (PlayerPrefs.GetInt("win") != 0) StartCoroutine("WinDialog");
    }

    IEnumerator Dialog() {
        yield return new WaitForSeconds(1);
        dialog1.SetActive(true);
        yield return new WaitForSeconds(6);
        dialog1.SetActive(false);
        dialog2.SetActive(true);
        yield return new WaitForSeconds(6);
        dialog2.SetActive(false);
        dialog3.SetActive(true);
        yield return new WaitForSeconds(10);
        dialog3.SetActive(false);
        PlayerPrefs.SetString("dialog", "true");
    }
    IEnumerator WinDialog() {
        yield return new WaitForSeconds(0.5f);
        dialog5.SetActive(true);
        yield return new WaitForSeconds(6);
        dialog5.SetActive(false);
    }
}

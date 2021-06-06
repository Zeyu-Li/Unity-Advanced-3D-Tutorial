using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectScreen : MonoBehaviour
{
    RaycastHit hit;
    public GameObject UIDisplay;
    public string cabinetTag = "Screen";
    public float maxDistance = 2.0f;

    public GameObject dialog4;

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var cameraTransform = Camera.main.GetComponent<Transform>();
        // Debug.DrawRay(cameraTransform.position, cameraTransform.forward * maxDistance, Color.green);
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance)) {
            Transform selection = hit.transform;

            if (selection.CompareTag(cabinetTag)) {
                var selectionRenderer = selection.GetComponent<Renderer>();

                if (selectionRenderer != null) {
                    // show UI element
                    UIDisplay.SetActive(true);
                    
                    if (PlayerPrefs.GetString("screenDialog") == "") StartCoroutine("Dialog");

                    PlayerPrefs.SetString("screenDialog", "true");
                }
            } else {
                UIDisplay.SetActive(false);
            }
        } else {
            UIDisplay.SetActive(false);
        }
    }

    IEnumerator Dialog() {
        if (PlayerPrefs.GetString("dialog") == "") {
            yield return new WaitForSeconds(3f);
        }
        yield return new WaitForSeconds(0.5f);
        dialog4.SetActive(true);
        yield return new WaitForSeconds(10);
        dialog4.SetActive(false);
    }

}

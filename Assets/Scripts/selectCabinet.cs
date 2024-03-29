using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectCabinet : MonoBehaviour
{
    RaycastHit hit;
    public GameObject UIDisplay;
    public GameObject UIPickup;
    public string cabinetTag = "Cabinet";
    public string flashlightTag = "Flashlight";
    public float maxDistance = 2.0f;
    public GameObject playerFlashlight;

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
                    if (Input.GetKeyDown(KeyCode.E)) {
                        // get selection
                        var sectionAnimator = selection.parent;
                        // animate cabinet
                        sectionAnimator.GetComponent<Animator>().SetBool("openCabinet", true);
                        // set tag to opened cabinet
                        selectionRenderer.gameObject.tag = "OpenCabinet";
                    } else {
                        // show UI element
                        UIDisplay.SetActive(true);
                    }
                }
            } else if (selection.CompareTag(flashlightTag)) {
                if (Input.GetKeyDown(KeyCode.E)) {
                    // flashlight pick up
                    var selectionRenderer = selection.GetComponent<Renderer>();
                    selectionRenderer.enabled = false;
                    PlayerPrefs.SetString("flashlight", "true");
                    playerFlashlight.SetActive(true);
                } else {
                    // show UI element
                    UIPickup.SetActive(true);
                }
            } else {
                UIDisplay.SetActive(false);
                UIPickup.SetActive(false);
            }
        } else {
            UIDisplay.SetActive(false);
            UIPickup.SetActive(false);
        }
    }
}

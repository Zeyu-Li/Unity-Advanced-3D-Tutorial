using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select : MonoBehaviour
{
    RaycastHit hit;
    public GameObject UIDisplay;
    public string cabinetTag = "Cabinet";
    public float maxDistance = 2.0f;

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
                }
            } else {
                UIDisplay.SetActive(false);
            }
        } else {
            UIDisplay.SetActive(false);
        }
    }
}

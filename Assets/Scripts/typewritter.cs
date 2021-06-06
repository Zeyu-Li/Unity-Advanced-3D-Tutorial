using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typewritter : MonoBehaviour
{
    public Text textDisplay;
    public float typingSpeed = 0.05f;

    public string sentence;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Type");
    }

    // Update is called once per frame
    IEnumerator Type() {
        foreach (char letter in sentence.ToCharArray()) {
            if (letter == '\\') {
                textDisplay.text += '\n';
            } else {
                textDisplay.text += letter;
            }
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}

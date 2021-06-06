using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class terminal : MonoBehaviour
{
    public GameObject directoryLine;
    public GameObject responseLine;

    public InputField terminalInput;
    public GameObject userInputLine;
    public ScrollRect scrollObject;
    public GameObject messageList;

    Interpreter interpreter;

    private void Start() {
        interpreter = GetComponent<Interpreter>();
    }

    private void OnGUI() {
        if (terminalInput.isFocused && terminalInput.text != "" && Input.GetKeyDown(KeyCode.Return)) {
            // user input
            string userInput = terminalInput.text;

            // clear input
            ClearInputField();

            // create shell pre char
            AddDirectoryLine(userInput);

            // interpretation
            int lines = AddInterpreterLines(interpreter.Interpret(userInput));

            // scroll to bottom
            ScrollToBottom(lines);

            // move user input to end
            userInputLine.transform.SetAsLastSibling();

            // refocus input field
            terminalInput.ActivateInputField();
            terminalInput.Select();
        }
    }

    private void ClearInputField() {
        terminalInput.text = "";
    }
    private void AddDirectoryLine(string userInput) {
        Vector2 messageListSize = messageList.GetComponent<RectTransform>().sizeDelta;
        messageList.GetComponent<RectTransform>().sizeDelta = new Vector2(messageListSize.x, messageListSize.y + 50.0f);

        GameObject message = Instantiate(directoryLine, messageList.transform);

        message.transform.SetSiblingIndex(messageList.transform.childCount - 1);

        message.GetComponentsInChildren<Text>()[1].text = userInput;
    }

    int AddInterpreterLines(List<string> interpretation) {
        for (int i = 0; i < interpretation.Count; i++) {
            // instantiate response line
            GameObject res = Instantiate(responseLine, messageList.transform);

            // set to end of messages
            res.transform.SetAsLastSibling();

            Vector2 listSize = messageList.GetComponent<RectTransform>().sizeDelta;
            messageList.GetComponent<RectTransform>().sizeDelta = new Vector2(listSize.x, listSize.y + 50f);

            res.GetComponentInChildren<Text>().text = interpretation[i];
        }

        return interpretation.Count;
    }

    void ScrollToBottom(int lines) {
        if (lines > 4) {
            scrollObject.velocity = new Vector2(0, 450);
        } else {
            scrollObject.verticalNormalizedPosition = 0;
        }
    }
}

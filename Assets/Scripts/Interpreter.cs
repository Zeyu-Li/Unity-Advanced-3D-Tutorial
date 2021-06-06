using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interpreter : MonoBehaviour
{
    public GameObject shooterGame;
    public GameObject terminalUI;
    List<string> response = new List<string>();

    public List<string> Interpret(string userInput) {
        response.Clear();

        // split
        string[] args = userInput.Trim().Split();

        if (args[0] == "help") {
            response.Add("A list of commands are listed below");
            response.Add("<color=#22A421>help</color> - a list of commands");
            response.Add("<color=#22A421>decode </color><color=#cf08c8>args</color> - decodes the");
            response.Add("message args (case sensitive)");
            response.Add("<color=#22A421>password</color> <color=#cf08c8>args</color> - enter the password as args");
            response.Add("<color=#22A421>exit</color> - exit shell environment");

            return response;
        } else if (args[0] == "exit") {
            // load back to other scene
            response.Add("exiting...");
            SceneManager.LoadScene("Main");

            return response;
        } else if (args[0] == "password") {
            // check password
            try {
                if (args[1] != "666") {
                    response.Add("<color=#FF0000>The password you entered is incorrect</color>");
                    response.Add("please try again");
                    
                    return response;
                }
                // enter 2D shooter
                response.Add("virtualizing...");

                shooterGame.SetActive(true);
                terminalUI.SetActive(false);

                return response;
            } catch {
                response.Add("You did not provide a password");
                response.Add("Please use the <color=#22A421>help</color> command if you want a refresher");
                
                return response;
            }
        } else if (args[0] == "decode") {
            // decode message
            try {
                string decodedText = Encoding.UTF8.GetString(Convert.FromBase64String(args[1]));
                response.Add(decodedText);
                
                return response;
            } catch (IndexOutOfRangeException) {
                response.Add("You did not provide an argument to decode");
                response.Add("Please use the <color=#22A421>help</color> command if you want a refresher");
                
                return response;
            } catch {
                response.Add("Could not decode properly, try again :(");
                
                return response;
            }
        } else if (args[0] == "whoami") {
                response.Add("Consumed by darkness and tormented by light");
                response.Add("you are the one prophesied");
                
                return response;
        } else {
            response.Add("This command is unknown");
            response.Add("use <color=#22A421>help</color> to find a list of all the usuable commands");

            return response;
        }
    }
}

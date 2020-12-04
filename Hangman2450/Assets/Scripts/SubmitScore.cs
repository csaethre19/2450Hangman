using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SubmitScore : MonoBehaviour
{
    public string theName;
    public GameObject inputField;
    public GameObject textDisplay;

    public void StoreName()
    {
        theName = inputField.GetComponent<Text>().text;
        

        Debug.Log("Button Pressed");

        if (LeadMenu.LeadboardChecker.RecordScore(Clue.gameScore, theName))
        {
            textDisplay.GetComponent<Text>().text = "Score Submitted! You may click 'Reset' to play again.";
        }

        
    }
}

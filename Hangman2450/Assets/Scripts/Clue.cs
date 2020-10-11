using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Clue : MonoBehaviour
{
    private Text clue;
    public GameObject clueObj;
    private string word = "crazy";
    private List<String> clueLetters = new List<String>();
    void Start()
    {
        clue = clueObj.GetComponent<Text>();
        for (int i = 0; i < word.Length; i++)
        {
            clueLetters.Add("_");
        }
        PrintClue();
        GameEvent.current.onGuessCheckLetter += CheckGuess;
    }

    // Update is called once per frame
    void Update()
    {
        PrintClue();
    }

    private void PrintClue()
    {
        string updatedClue = "";
        for (int i = 0; i < clueLetters.Count; i++)
        {
            updatedClue += clueLetters[i] + " ";
        }
        clue.text = updatedClue;
    }

    private void CheckGuess(char letter)
    {
        Boolean correct = false;
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == letter)
            {
                //Modify Clue
                clueLetters.Insert(i, letter.ToString());
                clueLetters.RemoveAt(i + 1);
                correct = true;
            }
        }
        if (!correct) GameEvent.current.decrement();
        //check for win
        if (!clueLetters.Contains("_"))
        {
            Debug.Log("You have won!");
        }

    }

}
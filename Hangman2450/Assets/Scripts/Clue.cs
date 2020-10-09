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
    public Text clue;
    private string word = "abcd";
    private char[] clueArray;
    private int lives = 6;
    void Start()
    {
        clueArray = new char[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            clueArray[i] = '_';
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
        for (int i = 0; i < clueArray.Length; i++)
        {
            updatedClue += clueArray[i] + " ";
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
                clueArray[i] = letter;
                correct = true;
            }
        }
        if (!correct) lives--;
        Debug.Log("Lives remaining: " + lives);
        //check for win
        if (lives == 0) Debug.Log("You have lost!");
        string clueString = string.Join("", clueArray);
        if (clueString.Equals(word))
        {
            Debug.Log("You have won!");
        }

    }

}
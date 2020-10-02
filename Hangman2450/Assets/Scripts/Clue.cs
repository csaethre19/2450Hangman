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
    private string word = "unityu";
    private char[] clueLetters;
    void Start()
    {
        clueLetters = new char[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            clueLetters[i] = '_';
        }
        PrintClue();
    }

    // Update is called once per frame
    void Update()
    {
        PrintClue();
    }

    private void PrintClue()
    {
        string updatedClue = "";
        for (int i = 0; i < clueLetters.Length; i++)
        {
            updatedClue += clueLetters.ElementAt(i) + " ";
        }
        clue.text = updatedClue;
    }

    public void CheckGuess(char letter)
    {
        char[] letters = word.ToCharArray();
        for (int i = 0; i < letters.Length; i++)
        {
            if (letter.Equals(letters.ElementAt(i)))
            {
                //Modify Clue
                clueLetters[i] = letter;
            }
            else
            {
                //decrement lives
            }

        }

    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using TMPro;
using UnityEditorInternal;
using UnityEngine;
//using UnityEngine.UI;

public class Clue : MonoBehaviour
{
    //public Text clue;
    private string word = "unity";
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
        //clue.text = updatedClue;
    }

    public void ModifyClue(char letter)
    {
        char[] letters = word.ToCharArray();
        for (int i = 0; i < letters.Length; i++)
        {
            if (letters.ElementAt(i) == letter)
            {
                clueLetters[i] = letter;
            }
        }
        
    }

    public Boolean CheckGuess(char letter)
    {
        if (word.Contains(letter.ToString()))
        {
            return true;
        }
        return false;
    }

}

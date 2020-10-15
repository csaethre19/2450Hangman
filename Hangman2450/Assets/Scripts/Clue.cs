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
    private string word = ""; //TODO get random word from wordlist
    private List<String> clueLetters;


    void Start()
    {
        WordListImport.ReadCSVFile();
        GetWord(word);
        CustomGameEventSystem.getWordFromList += GetWord;

        clue = gameObject.GetComponent<Text>();
        clueLetters = new List<String>();

        for (int i = 0; i < word.Length; i++)
        {
            clueLetters.Add("_");
        }

        PrintClue();
        CustomGameEventSystem.onGuess += CheckGuess;
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
        if (!correct) {
            CustomGameEventSystem.BroadcastChangeLives(-1);
        }
        //check for win
        if (!clueLetters.Contains("_"))
        {
            Debug.Log("You have won!");
        }

    }

    private void GetWord(String s)
    {
        word = WordListImport.getWord();
        CustomGameEventSystem.BroadcastWordFromList(word);
    }


}
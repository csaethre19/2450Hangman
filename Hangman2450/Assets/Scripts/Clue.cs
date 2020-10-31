using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Clue : MonoBehaviour
{
    private Text clue; 
    private string word = "";
    private List<String> clueLetters;
    bool gameFinished;

    void Start()
    {
        //Read CSV File and get a word into our word variable
        WordListImport.ReadCSVFile();
        word = WordListImport.getWord();

        //reference to the text component on this object
        clue = gameObject.GetComponent<Text>();

        //Array of strings to modify for the clue display
        clueLetters = new List<String>();


        //Add a "Blank" For each letter in Word
        for (int i = 0; i < word.Length; i++)
        {
            clueLetters.Add("_");
        }

        PrintClue();
        CustomGameEventSystem.onGuess += CheckGuess;
        CustomGameEventSystem.onGameFinished += GameFinished;

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnDestroy() {
        CustomGameEventSystem.onGuess -= CheckGuess;
        CustomGameEventSystem.onGameFinished -= GameFinished;
    }

    private void PrintClue()
    {
        if (!gameFinished) {
            string updatedClue = "";
        for (int i = 0; i < clueLetters.Count; i++)
        {
            updatedClue += clueLetters[i] + " ";
        }
        clue.text = updatedClue.ToUpper();
        }
    }

    private void CheckGuess(char letter)
    {
         
            Boolean correct = false;
            for (int i = 0; i < word.Length; i++) {
                if (word[i] == letter) {
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
            if (!clueLetters.Contains("_")) {
                CustomGameEventSystem.BroadcastGameFinished(true);
            }
            
                PrintClue();

       
    }

    public void GameFinished(bool gameWon) {
        gameFinished = true;
        Debug.Log("setting clue txt to word");
        clue.text = word.ToUpper();
    }


    /*Custom class to import words for the game from a CSV*
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * */
    public static class WordListImport {
        public static string[] data_values;
        public static string gameWord;
        public static string wordList; //Assigned when setWordListPath is called

        public static void setWordListPath()
        {
            string line = "";
            string level = "";
            StreamReader strReader = new StreamReader("Assets//WordBank//Level.txt");
            while ((line = strReader.ReadLine()) != null)
            {
                level = line;
            }

            switch (level)
            {
                default:
                    wordList = "List_1.csv";
                    break;
                case "1":
                    wordList = "List_2.csv";
                    break;
                case "2":
                    wordList = "List_3.csv";
                    break;
            }
        }

        public static void ReadCSVFile() {

            //Set the file path based on player selected level difficulty written to file during start menu scene
            setWordListPath();
            Debug.Log(wordList);

            //Scream the word to clue/ Event listener
            StreamReader strReader = new StreamReader("Assets//WordBank//" + wordList);
            bool endOfFile = false;
            while (!endOfFile) {
                string data_String = strReader.ReadLine();

                if (data_String == null) {
                    endOfFile = true;
                    break;
                }
                data_values = data_String.Split(',');
            }
        }

        public static string getWord() {
            Debug.Log("Fetching a Word");
            int randomWordIndex = Random.Range(0, data_values.Length);

            Debug.Log("Word Fetched from Index" + randomWordIndex);
            gameWord = data_values[randomWordIndex];

            Debug.Log("Here be the word: " + gameWord);
            return gameWord;
        }
    }

}
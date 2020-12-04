﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Clue : MonoBehaviour
{
    private Text clue;
    private string word = ""; //TODO get random word from wordlist
    private List<String> clueLetters;
    bool gameFinished;

<<<<<<< Updated upstream
=======
    public GameObject inputField;
    public GameObject textDisplay;
    public GameObject button;
    public static int gameScore;

>>>>>>> Stashed changes

    void Start()
    {
        //Read CSV File and get a word into our word variable
        WordListImport.ReadCSVFile();
        word = WordListImport.getWord();
        gameScore = word.Length * 100;

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

<<<<<<< Updated upstream
    private void OnDestroy() {
=======
    private void OnDestroy()
    {
>>>>>>> Stashed changes
        CustomGameEventSystem.onGuess -= CheckGuess;
        CustomGameEventSystem.onGameFinished -= GameFinished;
    }

    private void PrintClue()
    {
        if (!gameFinished)
        {
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
        if (!correct)
        {
            CustomGameEventSystem.BroadcastChangeLives(-1);
            gameScore = gameScore - 50;
        }
        //check for win
        if (!clueLetters.Contains("_"))
        {
            CustomGameEventSystem.BroadcastGameFinished(true);
        }

        PrintClue();
    }

    public void GameFinished(bool gameWon)
    {
        gameFinished = true;
        //Call leaderboard checker method

        if (LeadMenu.LeadboardChecker.IsHighScore(gameScore))
        {
            inputField.SetActive(true);
            button.SetActive(true);
            textDisplay.SetActive(true);
            textDisplay.GetComponent<Text>().text = "You got a high score! \nYour score: " + gameScore +
                "\nEnter your intials and click Submit!";
            //LeadMenu.LeadboardChecker.RecordScore(gameScore);
        }
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
    public static class WordListImport
    {
        public static string[] data_values;
        public static List<string> easyWords = new List<string>();
        public static List<string> mediumWords = new List<string>();
        public static List<string> hardWords = new List<string>();
        public static string gameWord;
<<<<<<< Updated upstream



        public static void ReadCSVFile() {

            //Scream the word to clue/ Event listener

            StreamReader strReader = new StreamReader("Assets//WordBank//List_1.csv");

            bool endOfFile = false;
            while (!endOfFile) {
                string data_String = strReader.ReadLine();

                if (data_String == null) {
                    endOfFile = true;
                    break;
                }

                data_values = data_String.Split(',');

                for (int i = 0; i < data_values.Length; i++) {
                    Debug.Log(data_values[i].ToString());
                }

                Debug.Log("File Imported");
                //getWord();
            }
        }

        public static string getWord() {
            Debug.Log("Fetching a Word");
            int randomWordIndex = Random.Range(0, data_values.Length);

            Debug.Log("Word Fetched from Index" + randomWordIndex);
            gameWord = data_values[randomWordIndex];
=======
        public static string wordList; 

        public static void ReadCSVFile()
        {

            //Scream the word to clue/ Event listener
            StreamReader strReader = new StreamReader("Assets//WordBank//List_1.csv");
            Debug.Log(wordList);
            bool endOfFile = false;
            while (!endOfFile)
            {
                string data_String = strReader.ReadLine();

                if (data_String == null)
                {
                    endOfFile = true;
                    break;
                }
                data_values = data_String.Split(',');

                for (int i = 0; i < data_values.Length; i++)
                {
                    if (data_values[i].Length <= 4)
                    {
                        easyWords.Add(data_values[i]);
                        //Debug.Log(data_values[i].ToString() + " was Added to Easy List!");
                    }
                    if (data_values[i].Length <= 8 && data_values[i].Length > 4)
                    {
                        mediumWords.Add(data_values[i]);
                        //Debug.Log(data_values[i].ToString() + " was Added to Medium List!");
                    }
                    if (data_values[i].Length > 8)
                    {
                        hardWords.Add(data_values[i]);
                        //Debug.Log(data_values[i].ToString() + " was Added to Hard List!");
                    }
                }
            }
            Debug.Log("File Imported");
        }

        public static string getWord()
        {

            string line = "";
            string level = "";
            StreamReader strReader = new StreamReader("Assets//WordBank//Level.txt");
            while ((line = strReader.ReadLine()) != null)
            {
                level = line;
            }

            int randomWordIndex = -1;

            Debug.Log("Fetching a Word");
            switch (level)
            {
                default:
                    randomWordIndex = Random.Range(0, easyWords.Count);
                    gameWord = easyWords[randomWordIndex];
                    break;
                case "1":
                    randomWordIndex = Random.Range(0, mediumWords.Count);
                    gameWord = mediumWords[randomWordIndex];
                    break;
                case "2":
                    randomWordIndex = Random.Range(0, hardWords.Count);
                    gameWord = hardWords[randomWordIndex];
                    break;
            }
>>>>>>> Stashed changes

            Debug.Log("Here be the word: " + gameWord);
            return gameWord;
        }
    }

}
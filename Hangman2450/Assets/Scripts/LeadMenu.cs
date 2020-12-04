using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using System.IO;
using UnityEngine.UI;
using System;

public class LeadMenu : MonoBehaviour
{
    public GameObject optMenu;
    public GameObject mainMenu;
    public GameObject leadMenu;
    public Text board;

    public static string[] data_values;

    private void Start()
    {
        board = gameObject.GetComponent<Text>();

        DisplayLeaderboard();
    }

    public void DisplayLeaderboard()
    {
        Stream iStream = new FileStream("Assets//WordBank//Leaderboard.csv",
        FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        
        StreamReader strReader = new System.IO.StreamReader(iStream);

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
                board.text += ($"{data_values[i]} ");
                Debug.Log(data_values[i]);
            }
            board.text += "\n";

        }
        strReader.Close();
        Debug.Log("Leaderboard Imported");
        
    }

    public void BackToStartScreen()
    {
        //Switch from Options Menu to Main Menu
        optMenu.SetActive(false);
        leadMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public static class LeadboardChecker
    {

        public static bool RecordScore(int gameScore, string initials)
        {
            Stream iStream = new FileStream("Assets//WordBank//Leaderboard.csv",
            FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            StreamReader strReader = new System.IO.StreamReader(iStream);

            bool endOfFile = false, scoreAdded = false;
            ArrayList tempArray = new ArrayList();
            String newLine;

            while (!endOfFile)
            {

                string data_String = strReader.ReadLine();
                tempArray.Add(data_String);

                if (data_String == null)
                {
                    endOfFile = true;
                    break;
                }


                data_values = data_String.Split(',');

                if (int.Parse(data_values[1]) <= gameScore && scoreAdded == false)
                {
                    DateTime thisDay = DateTime.Today;
                    newLine = $"{initials},{gameScore},{thisDay.ToString("d")}";
                    Debug.Log("New Score: \n" + newLine);

                    //tempArray.Add(data_String);
                    //tempArray.Add(newLine);
                    if (int.Parse(data_values[1]) < gameScore)
                    {
                        tempArray.Add(newLine);
                        tempArray.Add(data_String);
                    }
                    else if (int.Parse(data_values[1]) == gameScore)
                    {
                        tempArray.Add(data_String);
                        tempArray.Add(newLine);
                    } 

                    scoreAdded = true;
                    //Debug.Log("Score Added");
                }
            }
            saveLeaderBoard(tempArray);
            strReader.Close();
            return scoreAdded;
        }

        public static void saveLeaderBoard(ArrayList saveArray)
        {
            //Debug.Log("Items in Array: " + saveArray.Count);

            StreamWriter strWriter = new StreamWriter("Assets//WordBank//Leaderboard.csv", false);

            for (int i = 0; i < 10; i++)
            {
                strWriter.WriteLine(saveArray[i]);
                //Debug.Log("Now writing: " + saveArray[i] + " to index " + i);
            }


            strWriter.Close();
        }

        public static bool IsHighScore(int score)
        {
            Stream iStream = new FileStream("Assets//WordBank//Leaderboard.csv",
            FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            StreamReader strReader = new System.IO.StreamReader(iStream);

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

                if (score >= data_String[1])
                {
                    strReader.Close();
                    return true;
                }
            }
            strReader.Close();
            return false;
        }
    }
    }
     

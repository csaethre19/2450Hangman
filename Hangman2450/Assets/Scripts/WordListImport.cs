using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.Cryptography;

public class WordListImport : MonoBehaviour
{
    public static string[] data_values;
    public static string gameWord; 

    // Start is called before the first frame update
    void Start()
    {
        ReadCSVFile();
    }

    // Update is called once per frame
    public static void ReadCSVFile()
    {

        //Scream the word to clue/ Event listener

        StreamReader strReader = new StreamReader("Assets//WordBank//List_1.csv");

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
                Debug.Log(data_values[i].ToString());
            }

            Debug.Log("File Imported");
            //getWord();
        }
    }

    public static string getWord()
    {
        Debug.Log("Fetching a Word");
        int randomWordIndex = Random.Range(0, data_values.Length);

        Debug.Log("Word Fetched from Index" + randomWordIndex);
        gameWord = data_values[randomWordIndex];

        Debug.Log("Here be the word: " + gameWord);
        return gameWord;
    }
}

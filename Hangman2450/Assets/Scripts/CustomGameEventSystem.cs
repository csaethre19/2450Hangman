using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGameEventSystem : MonoBehaviour
{
    //delegate holds any method that takes one char as an argument
    public delegate void Guess(char letter);

    //Make an event using the delegate and call it onGuess
    public static event Guess onGuess;


    //Call this method when you want to trigger the event
    public static void BroadcastGuessLetter(char letter)
    {
        //make sure we have people that are listening for our event
        if (onGuess != null)
        {
            //broadcast event with the letter we were passed
            onGuess(letter);
        }
    }

    public delegate void ChangeLives(int n);
    public static event ChangeLives onChangeLives;


    public static void BroadcastChangeLives(int n)
    {
        if (onChangeLives != null)
        {
            onChangeLives(n);
        }
    }

    public delegate void Word(String s);
    public static event Word getWordFromList;
    public static void BroadcastWordFromList(String s)
    {
        if (getWordFromList != null)
        {
            getWordFromList(s);
        }
    }

}

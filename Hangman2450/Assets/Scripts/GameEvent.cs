using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public static GameEvent current;

    private void Awake()
    {
        current = this;
    }

    public event Action<char> onGuessCheckLetter;
    public void guessLetter(char letter)
    {
        if(onGuessCheckLetter != null)
        {
            onGuessCheckLetter(letter);
        }
    }

    public event Action TriggerDecrementLives;
    public void decrement()
    {
        if (TriggerDecrementLives != null)
        {
            TriggerDecrementLives();
        }
    }

}

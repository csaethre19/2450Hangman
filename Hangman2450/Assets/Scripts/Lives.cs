using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    private Text livesText;
    public GameObject livesObj;
    private int lives = 6;

    // Start is called before the first frame update
    void Start()
    {
        livesText = livesObj.GetComponent<Text>();
        GameEvent.current.TriggerDecrementLives += DecrementLives;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives > 0)
        {
            livesText.text = "Lives: " + lives;
        }
        else
        {
            livesText.text = "You have lost!";
        }
    }

    public void DecrementLives()
    {
        lives--;
    }
}

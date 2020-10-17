using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    private Text livesText;
    private int lives = 6;


    // Start is called before the first frame update
    void Awake()
    {
        livesText = gameObject.GetComponent<Text>();
        CustomGameEventSystem.onChangeLives += changeLives;
        CustomGameEventSystem.onGameFinished += GameFinished;
        livesText.text = "Lives: " + lives;

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnDestroy() {
        CustomGameEventSystem.onChangeLives -= changeLives;
        CustomGameEventSystem.onGameFinished -= GameFinished;
    }

    public void changeLives(int n)
    {
        if(lives != 0) {
            lives += n;
        }

        livesText.text = "Lives: " + lives;

        if (lives == 0) {
            CustomGameEventSystem.BroadcastGameFinished(false);
            GameFinished(false);

        }
       
    }

    private void GameFinished(bool gameWon) {


        Debug.Log("Game won: " + gameWon);
        if (gameWon) {
            livesText.text = "You Won!";
        }
        else {
            livesText.text = "Sorry. You Lost.";
        }

    }
}

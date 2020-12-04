using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
<<<<<<< Updated upstream
=======
    public GameObject optMenu;
    public GameObject mainMenu;
    public GameObject leaderboard;

    private void Start()
    {
        Screen.SetResolution(1920,1080, true);//sets our resolution to 1920x1080 and fullscreen so our UI doesn't look gross

        using (StreamWriter writer = new StreamWriter("Assets//WordBank//Level.txt"))
        {
            writer.WriteLine("0");
        }
    }
>>>>>>> Stashed changes
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
<<<<<<< Updated upstream
=======

    public void ChangeToOptionsMenu()
    {
        //Switch from Main Menu to Options Menu
        mainMenu.SetActive(false);
        optMenu.SetActive(true);
        leaderboard.SetActive(false);
    }

    public void ChangeToLeaderboard()
    {
        //Switch from Main Menu to Options Menu
        mainMenu.SetActive(false);
        optMenu.SetActive(false);
        leaderboard.SetActive(true);
    }
>>>>>>> Stashed changes
}

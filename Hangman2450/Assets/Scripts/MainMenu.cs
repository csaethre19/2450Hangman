using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public GameObject optMenu;
    public GameObject mainMenu;
    private void Start()
    {
        Time.timeScale = 1;
        Screen.SetResolution(1920,1080, true);//sets our resolution to 1920x1080 and fullscreen so our UI doesn't look gross

        using (StreamWriter writer = new StreamWriter("Assets//WordBank//Level.txt"))
        {
            writer.WriteLine("0");
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void ChangeToOptionsMenu()
    {
        //Switch from Main Menu to Options Menu
        mainMenu.SetActive(false);
        optMenu.SetActive(true);
    }
}

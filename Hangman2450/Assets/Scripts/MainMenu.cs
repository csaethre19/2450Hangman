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

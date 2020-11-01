using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using System.IO;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optMenu;
    public GameObject mainMenu;
    public Transform levels;

    public void SaveSelectedLevel()
    {
        using (StreamWriter writer = new StreamWriter("Assets//WordBank//Level.txt"))
        {
            writer.WriteLine(levels.GetComponent<Dropdown>().value);
        }
    }

    public void BackToStartScreen()
    {
        //Switch from Options Menu to Main Menu
        optMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}

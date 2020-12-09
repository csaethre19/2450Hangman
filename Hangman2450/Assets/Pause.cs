using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    bool paused = false;
    public GameObject PausedMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            PausedMenu.SetActive(paused);
            gameObject.GetComponent<Click>().SendMessage("DisableClick");
            gameObject.GetComponent<GunShot>().SendMessage("DisableGunShot");
            if (paused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
}

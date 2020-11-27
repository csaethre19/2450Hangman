using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	int score = 0;
	bool paused = false;
	public Text scoreText;
	public Text status;
	
    // Start is called before the first frame update
    void Start()
    {
        status.text = "";
    }

    // Update is called once per frame
    void Update()
    {
		//pause menu
       if(Input.GetKeyDown(KeyCode.P)){
		   if(paused == true){
			   Time.timeScale = 1f;
			   paused = false;
			   status.text = "";
		   } else {
			   paused = true;
			   status.text = "p a u s e d";
			   Time.timeScale = 0f;
		   }
		}
		
		if (paused == false) {
			score += 1;
			scoreText.text = "S C O R E : " + score;
		}
	}
	
	//end game method
	//restart game method
	//Pause Text
}

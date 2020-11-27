using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timeManager : MonoBehaviour
{

	public float slowdownFactor = 0.05f;
	public float slowdownLength = 2f;
	
	public bool gameOver = false;
	public int score = 0;
	public bool paused = false;
	public Text scoreText;
	public Text status;
	public Text replay;
	
	public AudioSource bgMusic;
	public ToggleCameraComponents toggle;
	
	void Start() {
		bgMusic.pitch = 1f;
		Time.timeScale = 1f;
		status.text = "";
		replay.text = "";
		toggle.disableGlitch();
	}
	
	public void slowMotion (){
		Time.timeScale = slowdownFactor;
		Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}

    // Update is called once per frame
    void Update()
    {
		//pause menu
       if(Input.GetKeyDown(KeyCode.P) && gameOver == false){
		   if(paused == true){
			   toggle.disableGlitch();
			   Time.timeScale = 1f;
			   paused = false;
			   status.text = "";
		   } else {
			   paused = true;
			   toggle.enableGlitch();
			   status.text = "p a u s e d";
			   Time.timeScale = 0f;
		   }
		}
		
		if (paused == false && !gameOver) {
			score += 1;
			scoreText.text = "S C O R E : " + score;
		}
		 if (gameOver == true){
			Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
			Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
		 }
		
		if(Input.GetKeyDown("space") && gameOver){
			restartGame();
		}
		
		bgMusic.pitch = Time.timeScale;
    }
	
	
	public void endGame(){
		gameOver = true;
		Invoke("gameOverScreen", 1f);
	}
	
	void gameOverScreen(){
		toggle.enableGlitch();
		status.text = "g a m e  o v e r";
		replay.text = "press [ s p a c e ] to replay...";
	}
	
	void restartGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}

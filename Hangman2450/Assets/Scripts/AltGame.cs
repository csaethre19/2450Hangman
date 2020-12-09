using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AltGame : MonoBehaviour
{
	GameObject[] spawns;
	public GameObject can;
	int rndSpawn;
	public float spawnTime = 0f;
	public Text scoreText;
	public Text canText;
	public TextMeshProUGUI status;
	public Text ammoText;
	public static int score = 0;
	public int force;
	float spawnTimer = 0;
	int totalSpawns = 25;
	int ammo = 25;
	bool gameOver = false;
	
	public GameObject camera;
	
    // Start is called before the first frame update
    void Start()
    {
		status.text = "";
		totalSpawns = 25;
		score = 0;
        spawns	= GameObject.FindGameObjectsWithTag("spawn");
    }

    // Update is called once per frame
    void Update()
    {
		if (ammo == 0){
				endGame();
			}
			
		if (Input.GetMouseButtonDown(0))
        {
			if (ammo > 0)
			{
				ammo -= 1;
			}
		}
		
		ammoText.text = "Ammo: " + ammo;
		canText.text = "Cans Left: " + totalSpawns;
		scoreText.text = "Score: " + score;
		
		spawnTimer -= Time.deltaTime;
		if (spawnTimer <= 0 && !gameOver){
			spawnTimer = spawnTime;
			SpawnCan();
			totalSpawns -= 1;
		}
		
	}
	
	void SpawnCan(){
		rndSpawn = Random.Range(0, spawns.Length);
		GameObject canClone = Instantiate(can, spawns[rndSpawn].transform.position, can.transform.rotation);
		canClone.GetComponent<Rigidbody>().AddForce(0, force, 0, ForceMode.VelocityChange);
	}
	
	void endGame(){
		status.text = "GAME OVER\n return to main menu";
		camera.GetComponent<Click>().SendMessage("DisableClick");
        camera.GetComponent<GunShot>().SendMessage("DisableGunShot");
		gameOver = true;
	}
}

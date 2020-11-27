using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	GameObject[] spawns;
	GameObject[] obstacles = new GameObject[2];
	
	public float spawnTime = 2f;
	public float spawnTimer;
	public int luck = 80;
	public int scorePointer = 2000;
	int rndPos;
	int rndObs;
	
	public GameObject ob1;
	public timeManager TimeManager;
	
	
    // Start is called before the first frame update
    void Start()
    {
		luck = 100;
		spawnTime = 1f;
		spawnTimer = spawnTime;
        spawns	= GameObject.FindGameObjectsWithTag("spawn");
		obstacles[0] = ob1;
		obstacles[1] = ob1;
    }

    // Update is called once per frame
    void Update()
    {
		if (TimeManager.score > scorePointer){
			if (spawnTime > 0){
				spawnTime -= .05f;
			}
			if (luck > 0){
				luck -= 8;
			}
			scorePointer += 2000;
		}
		
		if(TimeManager.gameOver == false){
			spawnObstacle();
		}
    }
	
	void spawnObstacle(){
		spawnTimer -= Time.deltaTime;
		if (spawnTimer <= 0) {
			rndObs = Random.Range(0, obstacles.Length);
			rndPos = Random.Range(0, spawns.Length);
			if (Random.Range(0,100) > luck){
				doubleSpawn();
			} else {
				singleSpawn();
			}
			spawnTimer = spawnTime;
		}
	}
	
	void singleSpawn(){
		Instantiate(obstacles[rndObs], spawns[rndPos].transform.position, obstacles[rndObs].transform.rotation);
	}
	
	void doubleSpawn(){
		int secondPos = Random.Range(0, spawns.Length);
		if (secondPos == rndPos){
			doubleSpawn();
		} else {
			Instantiate(obstacles[rndObs], spawns[rndPos].transform.position, obstacles[rndObs].transform.rotation);
			Instantiate(obstacles[rndObs], spawns[secondPos].transform.position, obstacles[rndObs].transform.rotation);
		}
	}
}
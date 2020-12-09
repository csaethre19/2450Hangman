using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	GameObject[] spawns;
	GameObject[] obstacles = new GameObject[2];
	
	float spawnTime = 2f;
	float spawnTimer;
	int luck = 100;
	int scorePointer = 5000;
	int rndPos;
	int rndObs;
	
	public GameObject ob1;
	public timeManager TimeManager;
	
    void Start()
    {
		luck = 100;
		spawnTime = 1f;
		spawnTimer = spawnTime;
        spawns	= GameObject.FindGameObjectsWithTag("spawn");
		obstacles[0] = ob1;
		obstacles[1] = ob1;
    }

    void Update()
    {
		if (TimeManager.score > scorePointer){
			if (luck > 0){
				luck -= 10;
			}
			if (spawnTime > .5f){
				spawnTime -= .1f;
			}
			scorePointer += 5000;
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
				doubleSpawn(rndObs);
			} else {
				singleSpawn(rndObs, rndPos);
			}
			spawnTimer = spawnTime;
		}
	}
	
	void singleSpawn(int obs, int pos){
		Instantiate(obstacles[obs], spawns[pos].transform.position, obstacles[obs].transform.rotation);
	}
	
	void doubleSpawn(int obs){
		List<GameObject> spawnCopy = new List<GameObject>();
		foreach (GameObject obj in spawns){
			spawnCopy.Add(obj);
		}
		int firstPos = Random.Range(0, spawns.Length);
		singleSpawn(obs, firstPos);
		spawnCopy.RemoveAt(firstPos);
		int secondPos = Random.Range(0, spawnCopy.Count);
		Instantiate(obstacles[obs], spawnCopy[secondPos].transform.position, obstacles[obs].transform.rotation);
	}
}
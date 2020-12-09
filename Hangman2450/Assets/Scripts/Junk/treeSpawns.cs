using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeSpawns : MonoBehaviour
{
	public GameObject leftSpawn;
	public GameObject rightSpawn;
	
	public Rigidbody leftTree;
	public Rigidbody rightTree;
	
	public float SpawnTime = 5f;
	float SpawnTimer;

	void Start(){
		SpawnTimer = SpawnTime;
	}

    void Update()
    {
        spawnTrees();
    }
	
	public void spawnTrees(){
		SpawnTimer -= Time.deltaTime;
		if (SpawnTimer <= 0){
			Instantiate(leftTree, leftSpawn.transform.position, leftTree.transform.rotation);
			Instantiate(rightTree, rightSpawn.transform.position, rightTree.transform.rotation);
			SpawnTimer = SpawnTime;
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
	public float speed = 1f;
	

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "death"){
			Destroy(gameObject);
		}
	}
	
	void Start(){
	}

    void Update()
    {
		if (Time.timeScale != 0){
			gameObject.transform.position += Vector3.back * speed;
		}
    }
}

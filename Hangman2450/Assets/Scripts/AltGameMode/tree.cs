using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
	float speed = 0.1f;
	float lifeSpan = 5f;
	
    void Update()
    {
		if (Time.timeScale != 0) {
			gameObject.transform.position += Vector3.back * speed;
		}
		lifeSpan -= Time.deltaTime;
		if (lifeSpan <= 0){
			Destroy(gameObject);
		}
    }
}

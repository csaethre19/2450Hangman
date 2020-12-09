using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altCan : MonoBehaviour
{
	float fall = 2f;
	float speed = .5f;
	float lifeSpan = 5f;
	
    void Update()
    {
		if (fall > 0){
			fall -= Time.deltaTime;
		} else {
			gameObject.transform.position += Vector3.down * speed;
		}
		lifeSpan -= Time.deltaTime;
		if (lifeSpan <= 0){
			Destroy(gameObject);
		}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
	public Rigidbody rb;
	public float speed = 0.4f;

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "death"){
			Destroy(gameObject);
		}
	}
	

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0,0,-speed, ForceMode.Impulse);
    }
}

using UnityEngine;

public class playerMovement : MonoBehaviour
{
	public Rigidbody player;
	public int moveSpeed = 100;
	
	public timeManager TimeManager;
	public GameObject boom;
	
    void FixedUpdate()
    {
        if (Input.GetKey("a")){
			player.AddForce(-moveSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
		
		if (Input.GetKey("d")){
			player.AddForce(moveSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
    }
	
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "obstacle"){
			TimeManager.slowMotion();
			Instantiate(boom, gameObject.transform.position, gameObject.transform.rotation);
			TimeManager.endGame();
			Destroy(gameObject);
			Destroy(col.gameObject);
		}
	}
}
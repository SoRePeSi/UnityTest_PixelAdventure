using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingPlatformSCR : MonoBehaviour{
	public float max;
	public float min;
	public float direction;
	public float speed;
	private Rigidbody2D rig;
	private Vector3 movement;
	
    void Start(){
		direction = 1f;
		rig = GetComponent<Rigidbody2D>();
		movement = new Vector3(direction,0f,0f);
    }
	
	void Update(){
		SlideSide();
	}
	
	void OnCollisionStay2D(Collision2D other){
		other.collider.attachedRigidbody.transform.position += movement * Time.deltaTime * speed;
	}
	
	void SlideSide(){
		if((transform.position.x<min && direction<0) || (transform.position.x>max && direction>0)){
			direction *= -1;
		movement = new Vector3(direction,0f,0f);
		}
		transform.position += movement * Time.deltaTime * speed;
	}
}

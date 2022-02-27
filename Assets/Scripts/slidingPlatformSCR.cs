using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingPlatformSCR : MonoBehaviour{
	public float max;
	public float min;
	public float direction;
	public float speed;
	public string horizVert;
	
	private Rigidbody2D rig;
	private Vector3 movementH;
	private Vector3 movementV;
	
    void Start(){
		direction = 1f;
		rig = GetComponent<Rigidbody2D>();
		movementH = new Vector3(direction, 0f, 0f);
		movementV = new Vector3(0f, direction, 0f);
	}
	
	void Update(){
		if(horizVert == "horizontal"){
			SlideSide();
		}
		else{
			SlideUp();
		}
	}
	
	void OnCollisionStay2D(Collision2D other){
		if(horizVert == "horizontal"){
			other.collider.attachedRigidbody.transform.position += movementH * Time.deltaTime * speed;
		}
		else{
			other.collider.attachedRigidbody.transform.position += movementV * Time.deltaTime * speed;
		}
	}
	
	void SlideSide(){
		if((transform.position.x < min && direction < 0) || (transform.position.x > max && direction > 0)){
			direction *= -1;
		movementH = new Vector3(direction, 0f, 0f);
		}
		transform.position += movementH * Time.deltaTime * speed;
	}
	
	void SlideUp(){
		if((transform.position.y < min && direction < 0) || (transform.position.y > max && direction > 0)){
			direction *= -1;
		movementV = new Vector3(0f, direction, 0f);
		}
		transform.position += movementV * Time.deltaTime * speed;
	}
}

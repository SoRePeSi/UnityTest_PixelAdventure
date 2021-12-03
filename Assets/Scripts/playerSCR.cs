using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSCR : MonoBehaviour{
	
	private Animator anim;
	private Rigidbody2D rig;
	
	public float Speed;
	public float Jumpforce;
	public int jumpAmount = 2;
	public int score = 0;
	public bool canMove = true;
	
	public Vector3 SpawnPoint;
	
    // Start is called before the first frame update
    void Start(){
        rig = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		SpawnPoint = new Vector3(-8f, -2f, 0f);
		Spawn();
    }

    // Update is called once per frame
    void Update(){
		Move();
		Jump();
    }
	
	void Move(){
		Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
		if(canMove){
			transform.position += movement * Time.deltaTime * Speed;
			if(Input.GetAxis("Horizontal")>0f){
				anim.SetBool("run", true);
				transform.eulerAngles = new Vector3(0f,0f,0f);
			}
			if(Input.GetAxis("Horizontal")==0f){
				anim.SetBool("run", false);
			}
			if(Input.GetAxis("Horizontal")<0f){
				anim.SetBool("run", true);
				transform.eulerAngles = new Vector3(0f,180f,0f);
			}
		}
		
		if(this.transform.position.y<-5){
			Spawn();
		}
	}
	
	void Jump(){
		if(jumpAmount>0){
			if(Input.GetButtonDown("Jump")){
				rig.AddForce(new Vector2(0f, Jumpforce), ForceMode2D.Impulse);
				jumpAmount--;
			}
		}
		if(rig.velocity.y>0f){
			if(jumpAmount==1){
				anim.SetBool("jump", true);
			}
			else{
				anim.SetBool("doubleJump", true);
			}
			anim.SetBool("fall", false);
		}
		if(rig.velocity.y<0f){
			anim.SetBool("fall", true);
			anim.SetBool("doubleJump", false);
			anim.SetBool("jump", false);
		}
		if(rig.velocity.y==0f){
			anim.SetBool("jump", false);
			anim.SetBool("doubleJump", false);
			anim.SetBool("fall", false);
			jumpAmount = 2;
		}
	}

	void Spawn(){
		transform.position = SpawnPoint;
	}
}
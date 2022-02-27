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
	public bool isGrounded = true;
	
	public Vector3 SpawnPoint;
	
	public GameObject interactObj;
	
	List<string> groundingTags = new List<string>() {"HorizontalOneWay", "Floor", "HorizontalPlatform"};
	
    void Start(){
        rig = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		SpawnPoint = new Vector3(-8f, -2f, 0f);
		Spawn();
    }

    void Update(){
		Move();
		Jump();
    }
	
	void Move(){
		Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
		
		if(canMove){
			transform.position += movement * Time.deltaTime * Speed;
			if(Input.GetAxis("Horizontal") > 0f){
				anim.SetBool("run", true);
				transform.eulerAngles = new Vector3(0f,0f,0f);
			}
			if(Input.GetAxis("Horizontal") == 0f){
				anim.SetBool("run", false);
			}
			if(Input.GetAxis("Horizontal") < 0f){
				anim.SetBool("run", true);
				transform.eulerAngles = new Vector3(0f,180f,0f);
			}
		}
		
		if(this.transform.position.y < -5){
			Spawn();
		}
	}
	
	void Jump(){
		string[] jumpType = {"", "doubleJump", "jump"};
		if(jumpAmount > 0){
			if(Input.GetButtonDown("Jump")){
				rig.velocity = new Vector2(rig.velocity.x, 0f);
				rig.AddForce(new Vector2(0f, Jumpforce), ForceMode2D.Impulse);
				anim.SetBool(jumpType[jumpAmount], true);
				jumpAmount--;
				isGrounded = false;
			}
		}
		
		if(!isGrounded){
			if(jumpAmount == 2){
				jumpAmount--;
			}
		}
		if(rig.velocity.y < 0f){
			anim.SetBool("fall", true);
			anim.SetBool("doubleJump", false);
			anim.SetBool("jump", false);
		}
		
		if(isGrounded){
			jumpAmount = 2;
			
			anim.SetBool("doubleJump", false);
			anim.SetBool("fall", false);
			anim.SetBool("jump", false);
		}
	}

	void Spawn(){
		transform.position = SpawnPoint;
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if(groundingTags.Exists(x => x == other.gameObject.tag)){
			isGrounded = true;
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcSCR : MonoBehaviour{
	
	public Text interText;
	public Transform Player;
	
	void Start(){
		Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player.GetComponent<Collider2D>());
		interText.enabled = false;
	}

	void Update(){
		if(Player.position.x < transform.position.x){
			transform.eulerAngles = new Vector3(0f, 180f, 0f);
		}
		else if(Player.position.x > transform.position.x){
			transform.eulerAngles = new Vector3(0f, 0f, 0f);
		}
		
		if((Player.position.x < transform.position.x - 2) || (Player.position.x > transform.position.x + 2)){
			interText.enabled = false;
		}
		else{
			interText.enabled = true;
		}
		
		
		try{
			interText.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, 0);
			interText.transform.eulerAngles = new Vector3(0f, 0f, 0f);
		}catch{}
	}
}
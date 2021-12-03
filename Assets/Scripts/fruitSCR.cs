using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fruitSCR : MonoBehaviour{
	public string fruitType;
	Animator anim;
	public Text scoreboard;
	public Canvas can;
	int pointWorth;
	
	playerSCR playerScript;
	
    // Start is called before the first frame update
    void Start(){
		anim = GetComponent<Animator>();
		
        SetType();
		
		playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<playerSCR>();
		can = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
		scoreboard = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Text>();
    }
	
	void SetType(){
		if(fruitType=="Strawberry"){
			anim.SetInteger("fruitType", 7);
			pointWorth = 1000;
		}
		else if(fruitType=="Pineapple"){
			anim.SetInteger("fruitType", 6);
			pointWorth = 500;
		}
		else if(fruitType=="Orange"){
			anim.SetInteger("fruitType", 5);
			pointWorth = 100;
		}
		else if(fruitType=="Melon"){
			anim.SetInteger("fruitType", 4);
			pointWorth = 50;
		}
		else if(fruitType=="Kiwi"){
			anim.SetInteger("fruitType", 3);
			pointWorth = 20;
		}
		else if(fruitType=="Cherry"){
			anim.SetInteger("fruitType", 2);
			pointWorth = 10;
		}
		else if(fruitType=="Banana"){
			anim.SetInteger("fruitType", 1);
			pointWorth = 5;
		}
		else{	// Apple
			anim.SetInteger("fruitType", 0);
			pointWorth = 1;
		}
	}

	public void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"){
			anim.SetBool("col", true);
			playerScript.score += this.pointWorth;
			string txt = "\n\n		SCORE: " + playerScript.score;
			scoreboard.text = txt;
		}
	}
	
	void DestroyFruit(){
		Destroy(gameObject);
	}
}

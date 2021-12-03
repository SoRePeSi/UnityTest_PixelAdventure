using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolineSCR : MonoBehaviour{
	Animator anim;
	playerSCR playerScript;
	
    // Start is called before the first frame update
    void Start(){
        anim = GetComponent<Animator>();
		playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<playerSCR>();
    }

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"){
			other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, playerScript.Jumpforce*1.5f), ForceMode2D.Impulse);
			anim.SetTrigger("isStepped");
		}
	}
}

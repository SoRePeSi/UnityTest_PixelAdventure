using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cpSCR : MonoBehaviour{
	Animator anim;
	playerSCR playerScript;
	bool activated;
	public int id;
	static int greaterId;
	
    // Start is called before the first frame update
    void Start(){
		activated = false;
        anim = GetComponent<Animator>();
		playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<playerSCR>();
		greaterId = 0;
    }
	
	public void OnTriggerEnter2D(Collider2D other){
		if(!this.activated){
			if(other.tag=="Player"){
				anim.SetBool("flagOut", true);
				if(id>greaterId){
					playerScript.SpawnPoint = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
					greaterId = id;
				}
			}
		}
	}
}

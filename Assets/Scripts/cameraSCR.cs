using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSCR : MonoBehaviour{
	public Transform player;
    // Start is called before the first frame update
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update(){
        Vector3 pos = transform.position;
		if(player.position.x>=-0.5f){
			pos.x = player.position.x;
			transform.position = pos;
		}
		if(player.position.y>=0){
			pos.y = player.position.y;
			transform.position = pos;
		}
    }
}

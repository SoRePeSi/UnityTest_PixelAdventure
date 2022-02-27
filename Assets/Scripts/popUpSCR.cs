using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popUpSCR : MonoBehaviour{
	public Transform fruit;
	Text fruitText;
	
	public fruitSCR fruitScript;
	
	float flyTimer = 0f;
	float disappearTimer = 0f;
	float flyTime = 0.3f;
	float disappearTime = 1f;
	
	string frutaTipo;
	
	void OnEnable(){
		fruitText = gameObject.GetComponent<Text>();
		
		fruitText.text = "+" + fruitScript.pointWorth.ToString();
		
		switch(fruitScript.pointWorth){
			case 1000:
				fruitText.color = new Color(0.45f,0.01f,0.8f);
				break;
			case 500:
				fruitText.color = new Color(0f,0.08f,0.63f);
				break;
			case 100:
				fruitText.color = new Color(0.9f,0.85f,0.07f);
				break;
			default:
				fruitText.color = new Color(1f,1f,1f);
				break;
		}
	}

	void Update(){
		flyTimer += Time.deltaTime;
		
		if(flyTimer < flyTime){
			transform.position += new Vector3(0f, flyTimer/10, 0f);
		}
		else{
			disappearTimer += Time.deltaTime;
			
			if(disappearTimer > disappearTime){
				Destroy(fruit.gameObject);
			}
		}
	}
}

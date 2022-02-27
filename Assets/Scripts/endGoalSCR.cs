using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endGoalSCR : MonoBehaviour{
	public int minScore;
	public Text minScoreText;
	public playerSCR scoreChecker;
	public CanvasGroup endImage;
	public CanvasGroup scoreScreen;
	
	Animator anim;
	
	float textTime = 2f;
	float fadeTime = 2f;
	float endTime = 4f;
	float timer = 0f;
	
	bool touch = false;
	bool gameOver = false;
	
	void Start(){
		minScoreText.enabled = false;
		anim = GetComponent<Animator>();
	}
	
	void Update(){
		if(touch){
			minScoreText.enabled = true;
			
			timer += Time.deltaTime;
			
			if(timer >= textTime){
				minScoreText.enabled = false;
				touch = false;
				timer = 0f;
			}
		}
		
		if(gameOver){
			timer += Time.deltaTime;
			
			endImage.alpha = timer / fadeTime;
			scoreScreen.alpha = 1 - timer/fadeTime;
			
			if(timer >= endTime){
				Application.Quit();
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			if(scoreChecker.score < minScore){
				touch = true;
			}
			else{
				anim.SetTrigger("Touched");
				End();
			}
		}
	}
	
	void End(){
		gameOver = true;
	}
}

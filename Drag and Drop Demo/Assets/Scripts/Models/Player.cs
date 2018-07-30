using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player{

	//Class properties
	public int score;
	public int level;
	public string email;

	public Player(string email, int score, int level){
		this.email = email;
		this.score = score;
		this.level = level;
		
	}
	
}

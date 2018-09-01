using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player{

	//Class properties
	public int score;
	public int level;
	public string email;

	public string fullName;

	public string professorName;
	public Player(string email, int score, int level, string professorName, string fullName ){
		this.email = email;
		this.score = score;
		this.level = level;
		this.professorName = professorName;
		this.fullName = fullName;
		
	}
	
}

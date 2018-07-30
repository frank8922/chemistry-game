using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Student  {

	public string course,email,name,room,time;

	
	public string toText(){
		return course + " " + email + " " + name + " " + room + " " + time;
	}
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

[System.Serializable]
public class AudioManager : MonoBehaviour {

	// Use this for initialization
	public Sound[] sounds;

	public static AudioManager instance;

	//awake is called before start
	void Awake(){
		//allows audio to persist through scenes
		DontDestroyOnLoad(gameObject);

		if(instance == null){
			instance = this;
			
		}else
		{
			Destroy(gameObject);
			return;//make sure no other code is run
		}

		foreach(Sound s in sounds){
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}
	void Start () {

		Play("theme");
		
	}
	
	public void Play(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s==null){
			Debug.LogWarning("Sound: " +  name + " not fond!");
			return;
		}
		s.source.Play();
	}
}

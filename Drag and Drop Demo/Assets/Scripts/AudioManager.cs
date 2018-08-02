using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

[System.Serializable]
public class AudioManager : MonoBehaviour {
	/*
	Manages the audio in a nice array
	 */

	public Sound[] sounds;

	public static AudioManager instance;

	//awake is called before start
	void Awake(){
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
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

		
		
	}
	
	public void Play(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s==null){
			Debug.LogWarning("Sound: " +  name + " not fond!");
			return;
		}
		s.source.Play();
	}

	//Think of way to fade the music and then stop it

	public void Stop(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s==null){
			Debug.LogWarning("Sound: " +  name + " not fond!");
			return;
		}
		s.source.Stop();
	}
}

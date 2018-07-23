﻿using UnityEngine;
using UnityEngine.Audio;
using System;

/*
This is a class to represent sound which we use in the audio manager
use this class to add foo to the audio manager
 */

[System.Serializable]
public class Sound {

	public AudioClip clip;
	[Range(0f,1f)]
	public float volume;
	[Range(.1f,3f)]
	public float pitch;

	public string name;

	public bool loop;

	[HideInInspector]public AudioSource source;
}

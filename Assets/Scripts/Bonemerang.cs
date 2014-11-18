﻿using UnityEngine;
using System.Collections;

public class Bonemerang : MonoBehaviour {
	
	public float lifetime;
	public GameObject shot;
	public Transform shotSpawn1;
	public GameObject bulletFolder;
	
	// Use this for initialization
	void Start () {
		bulletFolder = GameObject.Find ("Bullets");
		InvokeRepeating ("BoneSpawn", 0.05f, 0.5f);
		InvokeRepeating ("BoneSpawn", 0.1f, 0.5f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void BoneSpawn(){
		
		
		Transform t = ((GameObject)Instantiate (shot, shotSpawn1.position, shotSpawn1.rotation)).transform;
		t.parent = bulletFolder.transform;

		audio.Play ();
	}
}

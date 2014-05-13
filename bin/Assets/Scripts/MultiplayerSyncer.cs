﻿using System;
using UnityEngine;
using System.Collections;

[AddComponentMenu("Multiplayer/Multiplayer Syncer")]
public class MultiplayerSyncer : MonoBehaviour {
	public GameObject playerPrefab = null;

	// Use this for initialization
	void Start () {
		if (PhotonNetwork.room != null) {
			GameObject _myPlayer = PhotonNetwork.Instantiate("Player", new Vector3(10, 30, 0), Quaternion.identity, 0);
			_myPlayer.GetComponent<CharacterController>().controlMe = true;
			_myPlayer.GetComponent<CharacterController>().networkControl = false;
			_myPlayer.GetComponent<CharacterController>().sceneCamera = GameObject.Find ("ARCamera");
		}
		else if (GameObject.Find("SessionStarter") != null && GameObject.Find("SessionStarter").GetComponent<SessionStarter>().singlePlayer == true) {
			GameObject _pl = (GameObject) Instantiate(playerPrefab, new Vector3(10, 30, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
			_pl.GetComponent<CharacterController>().controlMe = true;
			_pl.GetComponent<CharacterController>().networkControl = false;
			_pl.GetComponent<CharacterController>().sceneCamera = GameObject.Find ("ARCamera");
			GameObject _ai = (GameObject) Instantiate(playerPrefab, new Vector3(20, 30, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
			_ai.GetComponent<CharacterController>().controlMe = false;
			_ai.GetComponent<CharacterController>().networkControl = false;
			_ai.GetComponent<CharacterController>().sceneCamera = GameObject.Find ("ARCamera");
		}
		else {
			Application.LoadLevel("MainMenu");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Awake()
	{
		// this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
		PhotonNetwork.automaticallySyncScene = true;
		
		// generate a name for this player, if none is assigned yet
		if (String.IsNullOrEmpty(PhotonNetwork.playerName))
		{
			PhotonNetwork.playerName = "Guest" + UnityEngine.Random.Range(1, 9999);
		}
	}
}
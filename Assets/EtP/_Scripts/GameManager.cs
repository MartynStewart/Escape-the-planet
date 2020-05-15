using UnityEngine;
using System.Collections.Generic;
using System;

using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {

	private int score = 0;
	private GameObject spawnRoom;
	private Zone currentZone;
	[SerializeField] private UIManager ui;
	AudioManager audioManager = AudioManager.GetInstance();


	public int newSeed;
	public IntVector2 mapSize;
	public Zone[] zones;


	private void Start() {
		spawnRoom = GameObject.Find("SpawnRoom");
		currentZone = zones[0];
		RandGen.SetSeed(newSeed);
		SetZoneSeeds();
		ui.UpdateZone(currentZone);
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) ResetGame();
	}


	public void BeginGame(Zone loadZone) {
		currentZone = loadZone;
		ui.UpdateZone(currentZone);
		spawnRoom.SetActive(false);
		GenMap.CreateMaze(currentZone, mapSize);
	}

	private void ResetGame() {
		spawnRoom.SetActive(true);
		currentZone = zones[0];
		ui.UpdateZone(currentZone);
		GenMap.ResetGame();
		audioManager.PlaySceneClip();
	}

	private void SetZoneSeeds() {
		foreach(Zone zone in zones) {
			zone.SetZoneSeed(RandGen.GenRandomSeed());
		}
	}

	public void CollectObject() {
		score++;
		ui.UpdateScore(score);
	}
}
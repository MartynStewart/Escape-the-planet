using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class GenMap: MonoBehaviour
{
    static private Zone currentZone;
    static private Maze mazeInstance;
    static private MazeCell[,] maze;
    static private List<GameObject> spawnedObjects = new List<GameObject>();
    static private Maze mazePrefab;
    static private GameObject player = GameObject.FindGameObjectWithTag("Player");
    static IntVector2 currentMapSize;


    public static void CreateMaze(Zone loadZone, IntVector2 mapSize) {

        if (mazeInstance != null) ResetGame();
        currentMapSize = mapSize;
        RandGen.SetSeed(loadZone.GetZoneSeed());
        currentZone = loadZone;
        mazePrefab = loadZone.mazePrefab;
        mazeInstance = Instantiate(mazePrefab) as Maze;
        mazeInstance.name = "Maze";
        maze = mazeInstance.Generate(mapSize);
        CreateSpawns();
        SetUpPlayer();
    }

    public static void ResetGame() {
        Destroy(mazeInstance.gameObject);
        DestroySpawns();
        player.transform.position = Vector3.zero;
    }

    private static void SetUpPlayer() {
        player.transform.position = maze[0, 0].transform.position;
    }

    private static void CreateSpawns() {
        for(int i = 0; i < 5; i++) {
            Vector3 spawnPos = maze[Random.Range(1, currentMapSize.x), Random.Range(1, currentMapSize.z)].transform.position;
            GameObject newSpawn = Instantiate(currentZone.crystalSpawn, spawnPos, Quaternion.identity);
        }
    }

    private static void DestroySpawns() {
                //Remove Zone spawns
    }

}

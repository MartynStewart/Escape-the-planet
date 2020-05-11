/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public IntVector2 iSize;
    public float loatTime;

    public Maze mazePrefab;
    private Maze mazeInstance;


    void Start() {
        BeginGame();
    
    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) RestartGame();
    }

    void BeginGame() {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        mazeInstance.CreateMaze(iSize, loatTime);
    }

    void RestartGame() {
        mazeInstance.StopMaze();
        Destroy(mazeInstance.gameObject);
        BeginGame();
    }
}
*/
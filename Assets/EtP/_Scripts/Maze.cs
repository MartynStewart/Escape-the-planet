using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    private IntVector2 iSize;
    private MazeCell mazeCellInstance;
    private MazeCell[,] cells;
    private float GenerationStepDelay = 0.5f;

    public MazeCell mazeCellPrefab;
    public MazePassage mazePassagePrefab;
    public MazeWall mazeWallPrefab;


    public IntVector2 RandomCoordinates {
        get {
            return new IntVector2(Random.Range(0, iSize.x), Random.Range(0, iSize.z));
        }
    }

    public void CreateMaze(IntVector2 size, float waitTime) {
        iSize = size;
        GenerationStepDelay = waitTime;
        StartCoroutine(GenerateMaze());
    }

    public void StopMaze() {
        StopCoroutine(GenerateMaze());
    }

    public MazeCell GetCell(IntVector2 a_coordinates) {
        return cells[a_coordinates.x, a_coordinates.z];
    }

    private IEnumerator GenerateMaze() {
        WaitForSeconds delay = new WaitForSeconds(GenerationStepDelay);
        cells = new MazeCell[iSize.x, iSize.z];
        List<MazeCell> activeCells = new List<MazeCell>();
        DoFirstGenerationStep(activeCells);

        while (activeCells.Count > 0) {
            yield return delay;
            DoNextGenerationStep(activeCells);
        }
    }

    private MazeCell CreateCell(IntVector2 myPos) {
        MazeCell newCell = Instantiate(mazeCellPrefab) as MazeCell;
        cells[myPos.x, myPos.z] = newCell;
        newCell.iCordinates = myPos;
        newCell.name = "MazeCell " + myPos.x + "-" + myPos.z;
        newCell.transform.parent = transform;
        newCell.transform.position = new Vector3(myPos.x - iSize.x * 0.5f + 0.5f, 0f, myPos.z - iSize.z * 0.5f + 0.5f);
        return newCell;
    }


    private void CreatePassage(MazeCell cell, MazeCell neighbourCell, MazeDirection direction) {
        MazePassage passage = Instantiate(mazePassagePrefab) as MazePassage;
        passage.Initialise(cell, neighbourCell, direction);
        passage = Instantiate(mazePassagePrefab) as MazePassage;
        passage.Initialise(neighbourCell, cell, direction.getOpposite());
    }

    private void CreateWall(MazeCell cell, MazeCell neighbourCell, MazeDirection direction) {
        MazeWall wall = Instantiate(mazeWallPrefab) as MazeWall;
        wall.Initialise(cell, neighbourCell, direction);
        if(neighbourCell != null) {
            wall = Instantiate(mazeWallPrefab) as MazeWall;
            wall.Initialise(neighbourCell, cell, direction.getOpposite());
        }
    }

    public bool ContainsCoords(IntVector2 coords) {
        bool xcheck = (coords.x >= 0 && coords.x < iSize.x);
        bool zcheck = (coords.z >= 0 && coords.z < iSize.z);
        return xcheck && zcheck;
    }

    private void DoFirstGenerationStep(List<MazeCell> ActiveCells) {
        ActiveCells.Add(CreateCell(RandomCoordinates));
    }

    private void DoNextGenerationStep(List<MazeCell> ActiveCells) {

        int iCurrentIndex = ActiveCells.Count - 1;
        MazeCell currentCell = ActiveCells[iCurrentIndex];
        MazeDirection direction = MazeDirections.RandomValue;
        IntVector2 iCoordinates = currentCell.iCordinates + direction.ToIntVector2();

        if (ContainsCoords(iCoordinates)) {
            MazeCell Neighbour = GetCell(iCoordinates);
            if (!Neighbour) {
                Neighbour = CreateCell(iCoordinates);
                CreatePassage(currentCell, Neighbour, direction);
                ActiveCells.Add(Neighbour);
            } else {
                CreateWall(currentCell, Neighbour, direction);
                ActiveCells.RemoveAt(iCurrentIndex);
            }
        } else {
            CreateWall(currentCell, null, direction);
            ActiveCells.RemoveAt(iCurrentIndex);
        }
    }


}

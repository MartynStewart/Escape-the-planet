using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Maze : MonoBehaviour {

    private MazeCell[,] cells;
	private IntVector2 size;
	private float gridSize = 2f;



	public float generationStepDelay = 0.5f;
    public MazeCell cellPrefab;
	public MazePassage passagePrefab;
	public MazeWall wallPrefab;


	public MazeCell GetCell(IntVector2 coordinates) {
		return cells[coordinates.x, coordinates.z];
	}

	public MazeCell[,] Generate(IntVector2 gridSize) {
		size = gridSize;
		cells = new MazeCell[size.x, size.z];
		List<MazeCell> activeCells = new List<MazeCell>();
		DoFirstGenerationStep(activeCells);
		while (activeCells.Count > 0) {
			DoNextGenerationStep(activeCells);
		}
		return cells;
	}

	private MazeCell CreateCell(IntVector2 coordinates) {
		MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
		cells[coordinates.x, coordinates.z] = newCell;
		newCell.coordinates = coordinates;
		newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
		newCell.transform.parent = transform;
		newCell.transform.localPosition = new Vector3((coordinates.x - size.x) * gridSize, 0f, (coordinates.z - size.z) * gridSize);
		return newCell;
	}


	public IntVector2 RandomCoordinates {
		get {
			return new IntVector2(Random.Range(0, size.x), Random.Range(0, size.z));
		}
	}

	public bool ContainsCoordinates(IntVector2 coordinate) {
		bool xCheck = coordinate.x >= 0 && coordinate.x < size.x;
		bool zCheck = coordinate.z >= 0 && coordinate.z < size.z;
		return xCheck && zCheck;
	}

	private void DoFirstGenerationStep(List<MazeCell> activeCells) {
		activeCells.Add(CreateCell(RandomCoordinates));
	}

	private void DoNextGenerationStep(List<MazeCell> activeCells) {
		int currentIndex = activeCells.Count - 1;
		MazeCell currentCell = activeCells[currentIndex];
		if (currentCell.IsFullyInitialized) {
			activeCells.RemoveAt(currentIndex);
			return;
		}
		MazeDirection direction = currentCell.RandomUninitializedDirection;
		IntVector2 coordinates = currentCell.coordinates + direction.ToIntVector2();
		if (ContainsCoordinates(coordinates)) {
			MazeCell neighbor = GetCell(coordinates);
			if (neighbor == null) {
				neighbor = CreateCell(coordinates);
				CreatePassage(currentCell, neighbor, direction);
				activeCells.Add(neighbor);
			} else {
				CreateWall(currentCell, neighbor, direction);
				// No longer remove the cell here.
			}
		} else {
			CreateWall(currentCell, null, direction);
			// No longer remove the cell here.
		}
	}

	private void CreatePassage(MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		MazePassage passage = Instantiate(passagePrefab) as MazePassage;
		passage.Initialize(cell, otherCell, direction);
		passage = Instantiate(passagePrefab) as MazePassage;
		passage.Initialize(otherCell, cell, direction.GetOpposite());
	}

	private void CreateWall(MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		MazeWall wall = Instantiate(wallPrefab) as MazeWall;
		wall.Initialize(cell, otherCell, direction);
		if (otherCell != null) {
			wall = Instantiate(wallPrefab) as MazeWall;
			wall.Initialize(otherCell, cell, direction.GetOpposite());
		}
	}
}
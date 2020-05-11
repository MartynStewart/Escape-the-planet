using UnityEngine;

public abstract class MazeCellEdge : MonoBehaviour
{

	public MazeCell cell, neighbour;

	public MazeDirection direction;


	public void Initialize(MazeCell cell, MazeCell neighbour, MazeDirection direction) {
		this.cell = cell;
		this.neighbour = neighbour;
		this.direction = direction;
		cell.SetEdge(direction, this);
		transform.parent = cell.transform;
		transform.localPosition = Vector3.zero;
		transform.localRotation = direction.ToRotation();
	}

}

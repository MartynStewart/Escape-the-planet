using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCellEdge : MonoBehaviour
{
    public MazeCell currentCell, neighbourCell;
    public MazeDirection direction;

    public void Initialise(MazeCell currentCell, MazeCell neighbourCell, MazeDirection direction) {

        this.currentCell = currentCell;
        this.neighbourCell = neighbourCell;
        this.direction = direction;
        currentCell.SetEdge(direction, this);
        transform.parent = currentCell.transform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = direction.ToRotate();

    }
}

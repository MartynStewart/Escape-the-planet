//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MazeCell : MonoBehaviour
//{
//    public IntVector2 iCordinates;
//    private int initialisedEdgeCount;
//    private MazeCellEdge[] edges = new MazeCellEdge[MazeDirections.Count];


//    public MazeCellEdge     GetEdge(MazeDirection direction)                        => edges[(int)direction];
//    public void SetEdge(MazeDirection direction, MazeCellEdge edge) {
//        edges[(int)direction] = edge;
//        initialisedEdgeCount++;

//    }

//    public bool isFullyInitialised {
//        get {
//            return edges.Length == initialisedEdgeCount;
//        }
//    }

//    public MazeDirection RandomUninitilisedDirection {
//        get {
//            int skips = Random.Range(0, MazeDirections.Count - initialisedEdgeCount);
//            for(int i = 0; i < MazeDirections.Count; i++) {
//                if(edges[i] == null) {
//                    if(skips == 0) {
//                        return (MazeDirection)i;
//                    }
//                    skips--;
//                }
//            }

//            throw new System.InvalidOperationException("MazeCell has no uninitilised directions left");
//        }
//    }

//}

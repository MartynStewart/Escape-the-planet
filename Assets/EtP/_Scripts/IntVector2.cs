using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct IntVector2
{
    public int x, z;

    public IntVector2(int x, int z) {
        this.x = x;
        this.z = z;
    }

    public static IntVector2 operator + (IntVector2 a, IntVector2 b) {
        IntVector2 returnVector;
        returnVector.x = a.x + b.x;
        returnVector.z = a.z + b.z;
        return returnVector;
    }



}

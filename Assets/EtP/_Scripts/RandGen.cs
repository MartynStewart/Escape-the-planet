using System;
using System.Data;
using UnityEditor.UIElements;
using UnityEngine;
using Random = UnityEngine.Random;

public static class RandGen {

    public static int currentSeed;


    public static void SetSeed(int newSeed) {
        currentSeed = newSeed;
        ResetRandom();
    }

    public static void ResetRandom() {
        UnityEngine.Random.InitState(currentSeed);
    }

    public static int GenRandomSeed() {
        int returnSeed = currentSeed;
        currentSeed = Random.Range(0, 999999);
        ResetRandom();
        return returnSeed;
    }


}

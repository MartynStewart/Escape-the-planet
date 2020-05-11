using UnityEngine;
using System.Collections;
using TMPro;

public class TimeKeeping : MonoBehaviour {

    [SerializeField] TextMeshProUGUI GameTime;
    float gameTime = 0;
    CollisionCounter cCounter = FindObjectOfType<CollisionCounter>();


    // Update is called once per frame
    void Update() {
        if (!cCounter.gameOver) {
            gameTime += Time.deltaTime;
        }
    }
}

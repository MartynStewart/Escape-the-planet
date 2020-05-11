using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    private GameManager gameManager;

    void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != "Player") return;
        gameManager.CollectObject();
        Destroy(this.gameObject);
    }

    void Update() {
        
    }
}

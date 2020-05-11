using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isActive = true;

    public float speed;


    void Start() {
        
    }

    void Update() {
        if (isActive)
        MovePlayer();
    }

    void MovePlayer() {
        float translateY    =   Input.GetAxis("Vertical")   * speed * Time.deltaTime;
        float translateX    =   Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(translateX, 0, translateY);
    }
}

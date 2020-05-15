using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    [SerializeField] GameObject godCube;
    [Range(3,120)] [SerializeField] float growRate;
    [Range(0.001f, 0.01f)] [SerializeField] float growStep;
    WaitForSeconds waitTime;
    bool isSplashActive = true;

    void Start() {
        waitTime = new WaitForSeconds(1 / growRate);
        StartCoroutine(SpinPulse());
    }

    IEnumerator SpinPulse() {
        while (isSplashActive) {
            godCube.transform.localScale += Vector3.one * growStep;
            if (godCube.transform.localScale.magnitude > 1.7f ) isSplashActive = false;
            yield return waitTime;
        }
    }

    public void MoveToMenu() {
            isSplashActive = false;
            StopCoroutine(SpinPulse());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class MazePortal : MonoBehaviour
{
    public Zone zonePort;
    private bool isActive = true;
    private ParticleSystem particleSys;
    AudioManager audioManager = AudioManager.GetInstance();

    private void Start() {
        particleSys = GetComponentInChildren<ParticleSystem>();
        foreach(MeshRenderer mesh in GetComponentsInChildren<MeshRenderer>()) {
            mesh.material.color = zonePort.zoneColour;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!isActive) return;
        isActive = false;
        particleSys.gameObject.SetActive(isActive);
        zonePort.SpawnZone();
        if (zonePort.zoneMusic) audioManager.PlayClip(zonePort.zoneMusic);
    }
}

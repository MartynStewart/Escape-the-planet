using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class AudioManager : MonoBehaviour
{
    static AudioManager instance;
    private AudioSource audioSource;

    public AudioClip[] audioClips;

    void Awake() {                      //Singleton
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        audioSource = instance.GetComponent<AudioSource>();      //Define the audiosource based on this object
        PlayTrack();
    }

    private void OnLevelWasLoaded(int level) {
        PlayTrack();
    }
    
    void PlayTrack() {
        
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        
        audioSource.Stop();
        if (audioClips == null || sceneNumber + 1 > audioClips.Length) return;
        audioSource.PlayOneShot(audioClips[sceneNumber]);
        audioSource.loop = true;
    }

    public float GetVolume() => audioSource.volume;
    public void SetVolume(float newVol) => audioSource.volume = Mathf.Clamp(newVol,0,1f);
    public void PlaySceneClip() => PlayTrack();
    public static AudioManager GetInstance() => instance;


    public void PlayClip(AudioClip clip) {
        audioSource.Stop();
        audioSource.PlayOneShot(clip);
    }

}

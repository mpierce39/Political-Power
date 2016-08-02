using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
    GameObject audioSource;
    public AudioSource audio;
    public bool toggleMusic;
	// Use this for initialization
	void Start () {
         audio = audioSource.GetComponentInChildren<AudioSource>();
         toggleMusic = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ToggleAudio() {
        if (toggleMusic == true)
        {

            audio.gameObject.SetActive(false);
        }
        else {
            audio.gameObject.SetActive(true);
        }

        }

    }



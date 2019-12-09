using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour {
    AudioClip heartBeat;
    AudioClip footStep;
    AudioSource heartBeatAudio;
    AudioSource footStepAudio;

    void Start() {
        heartBeat = (AudioClip)Resources.Load("Sounds/HeartBeat");
        footStep = (AudioClip)Resources.Load("Sounds/HeartBeat");
        heartBeatAudio = GameObject.FindWithTag("Player").transform.GetChild(1).GetComponent<AudioSource>();
        footStepAudio = GameObject.FindWithTag("Enemy").transform.GetChild(1).GetComponent<AudioSource>();

        heartBeatAudio.loop = true;
        footStepAudio.loop = true;
    }

    void Update() {
        if (Manager.startFlag && !footStepAudio.isPlaying) {
            footStepAudio.Play();
        }

        heartBeatAudio.volume = PlayerStatus.tension;
        heartBeatAudio.pitch = 1.0f + PlayerStatus.tension;

        footStepAudio.volume = 0.5f + EnemyStatus.tension / 2.0f;
    }
}

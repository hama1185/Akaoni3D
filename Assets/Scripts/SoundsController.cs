﻿using System.Collections;
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

        heartBeatAudio.volume = 0.6f - (PlayerStatus.mind - EnemyStatus.relaxed) / 250.0f;
        heartBeatAudio.pitch = 1.0f - (PlayerStatus.mind - EnemyStatus.relaxed) / 400.0f;
        // footStepAudio.volume = 0.5f + EnemyStatus.mind / 2.0f;
    }
}

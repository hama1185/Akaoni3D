using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour {
    AudioClip heartBeat;
    AudioClip footStep;
    AudioSource heartBeatAudio;
    AudioSource footStepAudio;
    AudioReverbZone audioZone;

    void Start() {
        heartBeat = (AudioClip)Resources.Load("Sounds/HeartBeat");
        footStep = (AudioClip)Resources.Load("Sounds/HeartBeat");
        heartBeatAudio = GameObject.FindWithTag("Player").transform.GetChild(1).GetComponent<AudioSource>();
        footStepAudio = GameObject.FindWithTag("Enemy").transform.GetChild(1).GetComponent<AudioSource>();
        audioZone = GameObject.FindWithTag("Player").transform.GetChild(1).GetComponent<AudioReverbZone>();
        heartBeatAudio.loop = true;
        footStepAudio.loop = true;
    }

    void Update() {
        if (Manager.startFlag && !footStepAudio.isPlaying) {
            footStepAudio.Play();
        }
        
        heartBeatAudio.volume = 1.0f - 8 * (PlayerStatus.mind) / 1000.0f;//0.2から1.0
        heartBeatAudio.pitch = 1.25f - (PlayerStatus.mind) / 200.0f;//0.75から1.25
        // footStepAudio.volume = 0.5f + EnemyStatus.mind / 2.0f;
        audioZone.maxDistance = 10.0f + 0.15f * EnemyStatus.relaxed;//10から30
    }
}
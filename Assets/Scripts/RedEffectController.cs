using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEffectController : MonoBehaviour {
    public Material red;
    float max = 0.06f;
    float min = 0.0f;

    void Update() {
        red.SetFloat("_Darkness", min + max * PlayerStatus.mind/100.0f);
    }
}
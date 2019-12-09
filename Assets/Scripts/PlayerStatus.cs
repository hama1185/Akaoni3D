using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    static float MAX_SPEED = 10.0f;

    // 緊張度パラメータ(仮)
    public static float tension {set; get;} = 0.2f;

    void Update() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            tension += 0.1f * Time.deltaTime;
            Debug.Log("Player : " + tension);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            tension -= 0.1f * Time.deltaTime;
            Debug.Log("Player : " + tension);
        }
    }

    public static float GetMAX_SPEED() {
        return MAX_SPEED;
    }
}
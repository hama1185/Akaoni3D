using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootController : MonoBehaviour
{
    public int initial = 600;
    // Start is called before the first frame update
    void Start(){
        StartCoroutine(Disappearing());
    }

    // Update is called once per frame
    IEnumerator Disappearing()//コルーチン
    {
        int step = initial + (int)(PlayerStatus.mind - EnemyStatus.relaxed)*5;
        for (int i = 0; i < step; i++)
        {
            GetComponent<MeshRenderer> ().material.color = new Color (1, 1, 1, 1 - 1.0f * i / step);
            yield return null;
        }
        Destroy (gameObject);
    }
}

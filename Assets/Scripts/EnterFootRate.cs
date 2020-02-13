using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterFootRate : MonoBehaviour
{
    // Start is called before the first frame update
 
    // Update is called once per frame
    void Update(){
        //例
        if(EnemyStatus.mind >= 20.0f && EnemyStatus.mind < 40.0f){
            FootSpawn.beatRate = 0.35f;
        }
    }
}

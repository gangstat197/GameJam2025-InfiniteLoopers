using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundCom : MonoBehaviour
{
    [HideInInspector] public string soundName;
    void Update(){
        if (GetComponent<AudioSource>().isPlaying == false){
            Destroy(this.gameObject);
        }
    }
}

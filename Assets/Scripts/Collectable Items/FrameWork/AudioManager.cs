using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public bool isTesting = false;
    public string calledSound;
    public Sound[] sounds;
    [HideInInspector] public List<GameObject> soundObjLst;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in sounds){
            GameObject soundObj = Instantiate(new GameObject(s.soundName), transform.position, transform.rotation, transform);
            soundObj.AddComponent<SoundCom>().soundName = s.soundName;
            AudioSource audioSource = soundObj.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.clip = s.clip;
            audioSource.volume = s.volume;
            audioSource.pitch = s.pitch;
            audioSource.loop = s.isLoop;
            soundObj.SetActive(false);
            soundObjLst.Add(soundObj);
            
        }
        Play("Background music");
        GameManager.OnGameStateChanged += AudioManagerOnGameStateChanged;
    }

    void OnDestroy() {
        GameManager.OnGameStateChanged -= AudioManagerOnGameStateChanged;
    }

    private void AudioManagerOnGameStateChanged(GameState state) {
    } 

    // Update is called once per frame
    void Update()
    {
        // if (isTesting && Input.GetMouseButtonDown(0)){
        //     Play(calledSound);
        // }
    }
    public void Play(string name){
        GameObject s = soundObjLst.Find(s => s.GetComponent<SoundCom>().soundName == name);
        // for ()
        if (s == null){
            Debug.LogWarning(String.Format("Sound '{0}' not found!", name));
            return;
        }
        else{
            Debug.Log("Enter");
            GameObject soundObj = Instantiate(s, transform.position, transform.rotation, transform);
            soundObj.SetActive(true);
            soundObj.GetComponent<AudioSource>().Play();
        }
        //.Play("Bubble pop 1")
    }
}

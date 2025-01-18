using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    
    public Sound[] sounds;
    [HideInInspector] public List<GameObject> soundObjLst;
    // Start is called before the first frame update
    new void Awake()
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(string name){
        GameObject s = soundObjLst.Find(s => s.GetComponent<SoundCom>().soundName == name);
        // for ()
        if (s == null){
            Debug.LogWarning(String.Format("Sound '{0}' not found!", name));
            return;
        }
        else{
            GameObject soundObj = Instantiate(s, transform.position, transform.rotation);
            soundObj.SetActive(true);
            soundObj.GetComponent<AudioSource>().Play();
        }
    }
}

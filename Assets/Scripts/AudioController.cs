using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour {
    public Sound[] sounds;
    public string[] music;
    public Sound currMusic;

    public static AudioController instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        currMusic.source = gameObject.AddComponent<AudioSource>();
    }

    void Update() {
        PlayMusic(music[SceneManager.GetActiveScene().buildIndex]);

    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void PlayMusic(string name) {
        if(name == "Credits") {
            name = music[PlayerPrefs.GetInt("PrevScene")];
        }
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (currMusic == null) {
            currMusic = s;
            currMusic.source.Play();
        } else if (currMusic.name != name) {
            currMusic.source.Stop();
            currMusic = s;
            currMusic.source.Play();
        }
    }
}

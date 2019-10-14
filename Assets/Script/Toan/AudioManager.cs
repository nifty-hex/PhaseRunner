using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    private float SFXmultiplier = 0.5f;

    private float BGMmultiplier = 0.5f;

    public bool isInProject = false;

    private Slow_Time slowtime;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            if (s.name == "BGM_Theme" || s.name == "BGM_Easy" || s.name == "BGM_Hard" || s.name == "BGM_Extreme")
            {
                s.source.volume = s.volume * BGMmultiplier;
            }
            else
            {
                s.source.volume = s.volume * SFXmultiplier;
            }

        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
            PlayMenu();
        else if (SceneManager.GetActiveScene().name == "Project")
        {
            slowtime = GameObject.Find("Player").GetComponent<Slow_Time>();
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Project")
        {
            isInProject = true;
            if (slowtime == null)
            {
                slowtime = GameObject.Find("Player").GetComponent<Slow_Time>();
            }
        }
        else
            isInProject = false;

        foreach (Sound s in sounds)
        {
            if (s.name == "BGM_Theme" || s.name == "BGM_Easy" || s.name == "BGM_Hard" || s.name == "BGM_Extreme")
            {
                s.source.volume = s.volume * BGMmultiplier;
                if (isInProject)
                {
                    if (slowtime.isSlowed())
                    {
                        s.source.pitch = s.pitch * 0.9f;
                    }
                    else
                    {
                        s.source.pitch = s.pitch;
                    }
                }         
            }
            else
            {
                s.source.volume = s.volume * SFXmultiplier;
            }
        }
    }

    public void PlayMenu()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "BGM_Theme");
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        if (!s.source.isPlaying)
            s.source.Play();
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound =>sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    public void Stop (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Stop();
    }

    public void StopAll ()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }

    public void changeSFXmult(float newMultiplier)
    {
        SFXmultiplier = newMultiplier;
    }

    public void changeBGMmult(float newMultiplier)
    {
        BGMmultiplier = newMultiplier;
    }

    public float getSFXMult()
    {
        return SFXmultiplier;
    }

    public float getBGMMult()
    {
        return BGMmultiplier;
    }
}

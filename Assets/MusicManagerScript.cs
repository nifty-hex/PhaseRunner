using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManagerScript : MonoBehaviour
{
    public static AudioClip menuMusic;
    static AudioSource audioSrc;
    string currentScene;

    // Start is called before the first frame update
    void Start()
    {
        menuMusic = Resources.Load<AudioClip>("menu music");
        audioSrc = GetComponent<AudioSource>();
        currentScene = "warning";
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name != currentScene || !audioSrc.isPlaying) // play music if it stops or scene changes
        {
            currentScene = scene.name;
            audioSrc.Stop();                // stop previous music
            switch (scene.name)
            {
                case "MainMenu":
                    PlayMusic("menu music");
                    break;
            }
        }
    }

    public static void PlayMusic(string song)
    {
        switch(song)
        {
            case "menu music":
                Debug.Log("ee");
                audioSrc.PlayOneShot(menuMusic);
                break;
        }
    }
}

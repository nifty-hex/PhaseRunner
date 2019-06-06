using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManagerScript : MonoBehaviour
{
    public static AudioClip menuMusic, easyMusic;
    static AudioSource audioSrc;
    public static string currentScene;
    public float pitch = 1.0f;
    private GameObject[] getCount;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        menuMusic = Resources.Load<AudioClip>("Sound/menu music");
        easyMusic = Resources.Load<AudioClip>("Sound/easy music");
        audioSrc = GetComponent<AudioSource>();
        currentScene = "warning";
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.pitch = pitch;
        CheckScene();
    }

    public void CheckScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != currentScene || !audioSrc.isPlaying)
        {
            SceneChange(scene);
        }
    }

    public void SceneChange(Scene scene)
    {
        currentScene = scene.name;
        audioSrc.Stop();                // stop previous music
        switch (scene.name)
        {
            case "MainMenu":
                PlayMusic("menu music");
                break;
            case "Project":
                PlayMusic("easy music");
                break;
            case "GameOver":
                Destroy(gameObject);
                break;
        }
    }

    public void PlayMusic(string song)
    {
        switch(song)
        {
            case "menu music":
                audioSrc.PlayOneShot(menuMusic);
                break;
            case "easy music":
                audioSrc.PlayOneShot(easyMusic);
                break;
        }
    }

    public static void DynamicMusic()
    {

    }
}

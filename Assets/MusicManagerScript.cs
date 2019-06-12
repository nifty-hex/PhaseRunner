using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManagerScript : MonoBehaviour
{
    public static AudioClip menuMusic, easyMusic, hardMusic, extremeMusic;
    static AudioSource audioSrc;
    public static string currentScene;
    public float pitch = 1.0f;
    public static float volume = 1.0f;
    private GameObject[] getCount;
    private static bool changeMusic = true;
    private static int hardScoreThreshold = 200;
    private static int extremeScoreThreshold = 400;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        menuMusic = Resources.Load<AudioClip>("Sound/menu music");
        easyMusic = Resources.Load<AudioClip>("Sound/easy music");
        hardMusic = Resources.Load<AudioClip>("Sound/hard music");
        extremeMusic = Resources.Load<AudioClip>("Sound/extreme music");
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

        if(scene.name == "Project")
            CheckScore();

        if (scene.name != currentScene || !audioSrc.isPlaying)
        {
            SceneChange(scene);
        }
    }

    public void SceneChange(Scene scene)
    {
        currentScene = scene.name;
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

    public static void PlayMusic(string song)
    {
        audioSrc.Stop();
        audioSrc.volume = volume;
        switch (song)
        {
            case "menu music":
                audioSrc.PlayOneShot(menuMusic);
                break;
            case "easy music":
                audioSrc.PlayOneShot(easyMusic);
                break;
            case "hard music":
                audioSrc.volume = 0.7f;
                audioSrc.PlayOneShot(hardMusic);
                break;
            case "extreme music":
                audioSrc.PlayOneShot(extremeMusic);
                break;
        }
    }

    public static void CheckScore()
    {
        GameObject Score_Text = GameObject.Find("Score_Text");
        Player_Score score = Score_Text.GetComponent<Player_Score>();
        if(score.player_score == hardScoreThreshold && changeMusic)
        {
            changeMusic = false;
            PlayMusic("hard music");
        }
        if (score.player_score == extremeScoreThreshold && !changeMusic)
        {
            changeMusic = true;
            PlayMusic("extreme music");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerHitSound, playerDieSound, playerJumpSound, slowDownSound, speedUpSound,
                            pistolSound, shotgunSound, railgunSound, machinegunSound,
                            enemyDestroySound, enemyShootSound, boomerShootSound,
                            heartPickupSound, reloadSound, alarmSound, glassBreakSound;
    static AudioSource audioSrc;
    public float pitch = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("Sound/hurt sound");
        playerDieSound = Resources.Load<AudioClip>("Sound/player die");
        speedUpSound = Resources.Load<AudioClip>("Sound/slow down");
        slowDownSound = Resources.Load<AudioClip>("Sound/speed up");
        playerJumpSound = Resources.Load<AudioClip>("Sound/jump");
        pistolSound = Resources.Load<AudioClip>("Sound/pistol");
        shotgunSound = Resources.Load<AudioClip>("Sound/shot gun");
        railgunSound = Resources.Load<AudioClip>("Sound/rail gun");
        machinegunSound = Resources.Load<AudioClip>("Sound/machine gun");
        heartPickupSound = Resources.Load<AudioClip>("Sound/heart pickup");
        reloadSound = Resources.Load<AudioClip>("Sound/reload");

        enemyDestroySound = Resources.Load<AudioClip>("Sound/Explosion");
        enemyShootSound = Resources.Load<AudioClip>("Sound/super pew");
        boomerShootSound = Resources.Load<AudioClip>("Sound/super pew 2");
        glassBreakSound = Resources.Load<AudioClip>("Sound/glass break");
        alarmSound = Resources.Load<AudioClip>("Sound/alarm");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.pitch = pitch;
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "hurt sound":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "speed up":
                audioSrc.PlayOneShot(speedUpSound);
                break;
            case "slow down":
                audioSrc.PlayOneShot(slowDownSound);
                break;
            case "reload":
                audioSrc.PlayOneShot(reloadSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(playerJumpSound);
                break;
            case "super pew 2":
                audioSrc.PlayOneShot(boomerShootSound);
                break;
            case "pistol":
                audioSrc.PlayOneShot(pistolSound);
                break;
            case "shot gun":
                audioSrc.PlayOneShot(shotgunSound);
                break;
            case "rail gun":
                audioSrc.PlayOneShot(railgunSound);
                break;
            case "machine gun":
                audioSrc.PlayOneShot(machinegunSound);
                break;
            case "Explosion":
                audioSrc.PlayOneShot(enemyDestroySound);
                break;
            case "super pew":
                audioSrc.PlayOneShot(enemyShootSound);
                break;
            case "player die":
                audioSrc.PlayOneShot(playerDieSound);
                break;
            case "glass break":
                audioSrc.PlayOneShot(glassBreakSound);
                break;
            case "heart pickup":
                audioSrc.PlayOneShot(heartPickupSound);
                break;
        }
    }
}








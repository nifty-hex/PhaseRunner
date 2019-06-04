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

    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("hurt sound");
        playerDieSound = Resources.Load<AudioClip>("player die");
        speedUpSound = Resources.Load<AudioClip>("slow down");
        slowDownSound = Resources.Load<AudioClip>("speed up");
        playerJumpSound = Resources.Load<AudioClip>("jump");
        pistolSound = Resources.Load<AudioClip>("pistol");
        shotgunSound = Resources.Load<AudioClip>("shot gun");
        railgunSound = Resources.Load<AudioClip>("rail gun");
        machinegunSound = Resources.Load<AudioClip>("machine gun");
        heartPickupSound = Resources.Load<AudioClip>("heart pickup");
        reloadSound = Resources.Load<AudioClip>("reload");

        enemyDestroySound = Resources.Load<AudioClip>("Explosion");
        enemyShootSound = Resources.Load<AudioClip>("super pew");
        boomerShootSound = Resources.Load<AudioClip>("super pew 2");
        glassBreakSound = Resources.Load<AudioClip>("glass break");
        alarmSound = Resources.Load<AudioClip>("alarm");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

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








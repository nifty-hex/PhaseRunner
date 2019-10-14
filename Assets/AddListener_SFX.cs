using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddListener_SFX : MonoBehaviour
{
    public Slider slider;
    private AudioManager audiomanager;

    void Awake()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        slider.value = audiomanager.getSFXMult();
        slider.onValueChanged.AddListener(delegate { audiomanager.changeSFXmult(slider.value); });
    }
}

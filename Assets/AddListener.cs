using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddListener : MonoBehaviour
{
    public Slider slider;
    private AudioManager audiomanager;

    void Awake()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        slider.value = audiomanager.getBGMMult();
        slider.onValueChanged.AddListener(delegate { audiomanager.changeBGMmult(slider.value); });
    }

}

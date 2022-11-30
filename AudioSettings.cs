using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public AudioMixerGroup mixer;
    public Slider musicSlider;
    public Slider soundSlider;

//    public AudioMixerSnapshot Normal;
//    public AudioMixerSnapshot Pause;

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Music", 1);
        soundSlider.value = PlayerPrefs.GetFloat("Sound", 1);
    }

    public void ChangeVolumeMusic(float volume)
    {
        mixer.audioMixer.SetFloat("Music", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("Music", volume);
    }


    public void ChangeVolumeSound(float volume)
    {
        mixer.audioMixer.SetFloat("Sound", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("Sound", volume);
    }

}

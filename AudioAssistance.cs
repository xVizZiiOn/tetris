using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioAssistance : MonoBehaviour
{

    public AudioMixerGroup mixer;

    public AudioSource rotate;
    public AudioSource speedUp;
    public AudioSource lineCollect;
    public AudioSource gameOver;


    void Start()
    {
        mixer.audioMixer.SetFloat("Music", Mathf.Lerp(-80, 0, PlayerPrefs.GetFloat("Music", 1)));
        mixer.audioMixer.SetFloat("Sound", Mathf.Lerp(-80, 0, PlayerPrefs.GetFloat("Sound", 1)));
    }

    public void RotateSound()
    {
        rotate.Play();
    }

    public void SpeedUpSound()
    {
        speedUp.Play();
    }

    public void LineCollectSound()
    {
        lineCollect.Play();
    }

    public void GameOverSound()
    {
        gameOver.Play();
    }


}

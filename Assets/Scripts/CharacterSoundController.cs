﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundController : MonoBehaviour
{
    public AudioClip jump;
    public AudioClip scoreHighlight;
    private AudioSource audioPlayer;

    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();    
    }

    public void PlaySound()
    {
        audioPlayer.PlayOneShot(jump);
    }

    public void playScoreHighlight()
    {
        audioPlayer.PlayOneShot(scoreHighlight);
    }
}

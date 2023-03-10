using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip relaxing_1;
    [SerializeField] private AudioClip relaxing_2;
    [SerializeField] private AudioClip white_noise_1;
    [SerializeField] private AudioClip white_noise_2;

    [SerializeField] private TMP_Dropdown _dropdown;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // EXTREMELY HARDCODED TO MATCH THE NAME OF DROPBOX ITEMS
    private AudioClip GetClip()
    {
        var songName = _dropdown.captionText.text;
        if (songName == "Relaxing 1")
        {
            return relaxing_1;
        }
        else if (songName == "Relaxing 2")
        {
            return relaxing_2;
        }
        else if (songName == "White Noise 1")
        {
            return white_noise_1;
        }
        else if (songName == "White Noise 2")
        {
            return white_noise_2;
        }

        return null; // no song
    }
    
    public void ChangeSong()
    {
        _audioSource.Stop();
        _audioSource.clip = GetClip();
        _audioSource.Play();
    }
}

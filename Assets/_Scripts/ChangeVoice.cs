using System;
using System.Collections;
using System.Collections.Generic;
using Meta.WitAi.TTS.Integrations;
using Meta.WitAi.TTS.Utilities;
using TMPro;
using UnityEngine;

// THIS CODE TO CHANGE VOICE DURING GAME DID NOT END UP WORKING
public class ChangeVoice : MonoBehaviour
{
    [SerializeField] private TTSWit tTSWit;
    [SerializeField] private TTSSpeaker tTSSpeaker;

    private TMP_Dropdown _dropdown;

    private void Start()
    {
        _dropdown = GetComponent<TMP_Dropdown>();
    }

    public void ChangeSpeakerVoice()
    {
        tTSSpeaker.VoiceSettings.settingsID = _dropdown.captionText.text;
    }

}

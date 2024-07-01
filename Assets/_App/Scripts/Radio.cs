using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using NAudio.Wave;

/// <summary>
/// More info about NAudio: https://github.com/AstralSkies/RadioUnityStream/blob/main/Assets/Scripts/RadioManager.cs
/// </summary>
public class Radio : MonoBehaviour
{
    private readonly string _url = "https://lidyi.com/radio/server.mp3";
    private AudioSource _audioSource;
    /// <summary>
    /// The MediaFoundationReader for audio processing.
    /// </summary>
    private MediaFoundationReader _mediaFoundationReader;

    /// <summary>
    /// The WaveOutEvent for audio output.
    /// </summary>
    private WaveOutEvent _waveOut;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        StartCoroutine(PlayRadio(_url));
    }

    private IEnumerator PlayRadio(string url)
    {
        yield return null; 
        try
        {
            _mediaFoundationReader = new MediaFoundationReader(url);
            _waveOut = new WaveOutEvent();
            _waveOut.Init(_mediaFoundationReader);
            _waveOut.Play();
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error playing radio: {ex.Message}");
        }
    }

    private void OnDestroy()
    {
        if (_waveOut != null)
        {
            _waveOut.Stop();
            _waveOut.Dispose();
        }

        if (_mediaFoundationReader != null)
        {
            _mediaFoundationReader.Dispose();
        }
    }
}

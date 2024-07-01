using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using NAudio.Wave;
using UnityEngine.UI;

/// <summary>
/// More info about NAudio: https://github.com/AstralSkies/RadioUnityStream/blob/main/Assets/Scripts/RadioManager.cs
/// </summary>
public class Radio : MonoBehaviour
{
    private readonly string _url = "http://stream.radioparadise.com/ogg-192";
    /// <summary>
    /// The MediaFoundationReader for audio processing.
    /// </summary>
    private MediaFoundationReader _mediaFoundationReader;

    /// <summary>
    /// The WaveOutEvent for audio output.
    /// </summary>
    private WaveOutEvent _waveOut;
    
    [SerializeField] private Button _playButton;
    [SerializeField] private Image _playImage;
    [SerializeField] private Sprite _playSprite;
    [SerializeField] private Sprite _pauseSprite;

    private void Awake()
    {
        _playButton.onClick.AddListener(() =>
        {
            if (_waveOut != null)
            {   
                if (_waveOut.PlaybackState == PlaybackState.Playing)
                {
                    _waveOut.Pause();
                    _playImage.sprite = _playSprite;
                }
                else
                {
                    _waveOut.Play();
                    _playImage.sprite = _pauseSprite;
                }
            }
        });
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
    
    public void PlayRadio()
    {
        if (_waveOut != null)
        {
            _waveOut.Play();
        }
    }
    
    public void StopRadio()
    {
        if (_waveOut != null)
        {
            _waveOut.Stop();
        }
    }

    public void SetVolume(float volume)
    {
        if (_waveOut != null)
        {
            _waveOut.Volume = Mathf.Clamp01(volume);
        }
    }

    public float GetVolume()
    {
        return _waveOut != null ? _waveOut.Volume : 0;
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void PlayAudio();
    [DllImport("__Internal")]
    private static extern void PauseAudio();
    [DllImport("__Internal")]
    private static extern void SetVolume(float volume);

    [SerializeField] private Button _playButton;
    [SerializeField] private Image _playImage;
    [SerializeField] private Sprite _playSprite;
    [SerializeField] private Sprite _pauseSprite;
    [SerializeField] private Slider _volumeSlider;

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        _playButton.onClick.AddListener(() =>
        {
            if (_playImage.sprite == _playSprite)
            {
                _playImage.sprite = _pauseSprite;
                PlayAudio();
            }
            else
            {
                _playImage.sprite = _playSprite;
                PauseAudio();
            }
        });
        
        _volumeSlider.onValueChanged.AddListener(value =>
        {
            SetVolume(value);
        });
#else
        Debug.Log("Streaming only supported in WebGL builds.");
#endif
    }
}

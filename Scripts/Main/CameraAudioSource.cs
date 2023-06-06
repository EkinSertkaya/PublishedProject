using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAudioSource : MonoBehaviour
{
    private AudioSource cameraAudioSource;

    [SerializeField] private Slider soundSlider;

    private void Start()
    {
        cameraAudioSource = GetComponent<AudioSource>();

        soundSlider.onValueChanged.AddListener(delegate { SetSoundLevel(); });
    }

    private void SetSoundLevel()
    {
        cameraAudioSource.volume = soundSlider.value;
    }
}

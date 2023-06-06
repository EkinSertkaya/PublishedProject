using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    private Slider soundSlider;

    private void Start()
    {
        soundSlider = GetComponent<Slider>();
    }
}

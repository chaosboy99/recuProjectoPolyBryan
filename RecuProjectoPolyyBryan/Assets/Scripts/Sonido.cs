using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sonido : MonoBehaviour
{
    public AudioSource Music;
    public Slider SliderAudio;

    public void VolumenAudio()
    {
        Music.volume = SliderAudio.value;
    }
}

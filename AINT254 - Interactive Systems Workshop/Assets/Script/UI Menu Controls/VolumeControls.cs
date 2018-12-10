using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControls : MonoBehaviour {

    //Code copied from a tutorial at https://johnleonardfrench.com/articles/the-right-way-to-make-a-volume-slider-in-unity-using-logarithmic-conversion/


    public AudioMixer mixer;

    public void SetMainLevel (float sliderValue)
    {
        Debug.Log(sliderValue);
        mixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }


    public void SetMusicLevel(float sliderValue)
    {
        Debug.Log(sliderValue);
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);

    }

    public void SetEffectsLevel(float sliderValue)
    {
        Debug.Log(sliderValue);
        mixer.SetFloat("EffectsVolume", Mathf.Log10(sliderValue) * 20);
    }
}

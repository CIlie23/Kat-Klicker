using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//inspider by this guy
// https://www.youtube.com/watch?v=k2vOeTK0z2g
public class saveSettings : MonoBehaviour {

    [Header("Music Volume")]
    [SerializeField] private Slider volSlider = null;

    // Use this for initialization
    private void Start () {
      LoadValues();
	}
    
    public void SaveVolumeButtom()
    {
        float volumeValue = volSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }

}

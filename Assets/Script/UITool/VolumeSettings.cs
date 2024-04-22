using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider fxSlider;
    [SerializeField] private Slider masterSlider;

    public void SetMusicVolume()
    {
        float musicSliderValue = musicSlider.value;
        myMixer.SetFloat("Music", musicSliderValue);
    }

    public void SetFxVolume()
    {
        float fxSliderValue = fxSlider.value;
        myMixer.SetFloat("Fx", fxSliderValue);
    }

    public void SetMasterVolume()
    {
        float masterSliderValue = masterSlider.value;
        myMixer.SetFloat("Master", masterSliderValue);
    }
}
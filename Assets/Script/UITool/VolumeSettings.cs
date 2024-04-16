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
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", volume);
    }

    public void SetFxVolume()
    {
        float Fxvolume = fxSlider.value;
        myMixer.SetFloat("Fx", Fxvolume);
    }

    public void SetMasterVolume()
    {
        float Mastervolume = masterSlider.value;
        myMixer.SetFloat("Master", Mastervolume);
    }
}
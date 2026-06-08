using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause Settings")]
    [SerializeField] private GameObject pauseMenu;


    [Header("Audio settings")]
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("volumeMaster", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("volumeMusic", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("volumeSFX", 1f);

        SetMasterVolume(masterSlider.value);
        SetMusicVolume(musicSlider.value);
        SetSFXVolume(sfxSlider.value);

        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SetMasterVolume(float value)
    {
        mixer.SetFloat("volumeMaster", Mathf.Log10(value) * 20);
    }

    public void SetMusicVolume(float value)
    {
        mixer.SetFloat("volumeMusic", Mathf.Log10(value) * 20);
    }

    public void SetSFXVolume(float value)
    {
        mixer.SetFloat("volumeSFX", Mathf.Log10(value) * 20);
    }
}
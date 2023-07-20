using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    #region Public Variables
    [Header("Array GameObjects:")]
    public GameObject[] Buttons;

    [Header("Canvas GameObject:")]
    public GameObject PauseMenu;

    public Toggle MusicToggle, SfxToggle;
    public Slider MusicSlider, SfxSlider;

    [Header("Canvas Menu Complementar GameObjects:")]
    public GameObject MainMenu;
    public Camera UICamera;
    public GameObject CreditsVideo;

    //private AudioSource MusicSource, SfxSource;
    #endregion

    private bool _pauseEnabled = false;

    void Start()
    {
        //MusicSource = GameObject.FindGameObjectWithTag("MusicSource").GetComponent<AudioSource>();
        //SfxSource = GameObject.FindGameObjectWithTag("SfxSource").GetComponent<AudioSource>();
        PauseMenu.SetActive(false);
    }

    void Update()
    {
        OnMouseDown();
        EnablePauseMenu();
        LoadMusicToggleValue();
        LoadSfxToggleValue();
        LoadMusicValue();
        LoadSfxValue();
    }

    #region OnMouseDown 
    void OnMouseDown()
    {
        Buttons[0].GetComponent<Button>().onClick.AddListener(ContinueGame); // Start Button
        Buttons[1].GetComponent<Button>().onClick.AddListener(OpenMainMenu); // Settings Button
    }
    #endregion

    #region PauseMenu
    private void EnablePauseMenu()
    {
        if (_pauseEnabled == false && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.SetActive(true);
            _pauseEnabled = true;
            Buttons[0].SetActive(true);
            Buttons[1].SetActive(true);
        }
        else if (_pauseEnabled == true && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.SetActive(false);
            _pauseEnabled = false;
        }
    } 
    #endregion

    #region ContinueGame
    void ContinueGame()
    {
        PauseMenu.SetActive(false);
        _pauseEnabled = false;
        Buttons[0].SetActive(false);
        Buttons[1].SetActive(false);
    } 
    #endregion

    void OpenMainMenu() 
    {
        Debug.Log("Voltou para o menu.");
        MainMenu.SetActive(true);
        UICamera.gameObject.SetActive(true);
        CreditsVideo.SetActive(true);
    }

    public void ToggleMusic()
    {
        //AudioManager.Instance.ToggleMusic();
        if (MusicToggle.isOn == true)
        {
            PlayerPrefs.SetInt("musicToggleValue", 0);
            //MusicSource.mute = false;
        }
        else if (MusicToggle.isOn == false)
        {
            PlayerPrefs.SetInt("musicToggleValue", 1);
            //MusicSource.mute = true;
        }
        LoadMusicToggleValue();
    }

    void LoadMusicToggleValue()
    {
        if (PlayerPrefs.HasKey("musicToggleValue"))
        {
            if (PlayerPrefs.GetInt("musicToggleValue") == 0) MusicToggle.isOn = true;
            else if (PlayerPrefs.GetInt("musicToggleValue") == 1) MusicToggle.isOn = false;
        }
        else PlayerPrefs.SetInt("musicToggleValue", 0);
    }

    public void ToggleSFX()
    {
        //AudioManager.Instance.ToggleSFX();
        if (SfxToggle.isOn == true)
        {
            PlayerPrefs.SetInt("sfxToggleValue", 0);
            //SfxSource.mute = false;
        }
        else if (SfxToggle.isOn == false)
        {
            PlayerPrefs.SetInt("sfxToggleValue", 1);
            //SfxSource.mute = true;
        }
    }

    void LoadSfxToggleValue()
    {
        if (PlayerPrefs.HasKey("sfxToggleValue"))
        {
            if (PlayerPrefs.GetInt("sfxToggleValue") == 0) SfxToggle.isOn = true;
            else if (PlayerPrefs.GetInt("sfxToggleValue") == 1) SfxToggle.isOn = false;
        }
        else PlayerPrefs.SetInt("sfxToggleValue", 0);
    }

    public void MusicVolume()
    {
        //AudioManager.Instance.MusicVolume(MusicSlider.value);
        float musicVolumeValue = MusicSlider.value;
        PlayerPrefs.SetFloat("MusicVolumeValue", musicVolumeValue);
        LoadMusicValue();
    }

    void LoadMusicValue()
    {
        float musicVolumeValue = PlayerPrefs.GetFloat("MusicVolumeValue");
        MusicSlider.value = musicVolumeValue;
    }

    public void SFXVolume()
    {
        //AudioManager.Instance.SFXVolume(SfxSlider.value);
        float sfxVolumeValue = SfxSlider.value;
        PlayerPrefs.SetFloat("SfxVolumeValue", sfxVolumeValue);
        LoadMusicValue();
    }

    void LoadSfxValue()
    {
        float sfxVolumeValue = PlayerPrefs.GetFloat("SfxVolumeValue");
        SfxSlider.value = sfxVolumeValue;
    }
}

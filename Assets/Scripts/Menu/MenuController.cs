using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    #region Public Variables
    [Header("Canvas GameObjects:")]
    public GameObject MainMenu;
    public GameObject CanvasSettings;
    public GameObject CanvasCredits;

    [Header("Array Return Buttons GameObjects:")]
    public GameObject[] ReturnToMenuButton;

    [Header("Array GameObjects:")]
    public GameObject[] Buttons;

    [Header("Transition GameObjects:")]
    public GameObject StartingTransition;
    public GameObject EndingTransition;

    [Header("Settings GameObjects:")]
    public AudioMixer AudioMixer;
    public TMP_Dropdown ResolutionDropdown;
    #endregion

    private Resolution[] resolutions;

    #region Methods

    void Start()
    {
        EnableEndTransition();

        resolutions = Screen.resolutions;

        ResolutionDropdown.ClearOptions();

        List<string> options = new();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = currentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
    }

    void Update()
    {
        OnMouseDown();
    }

    #region OnMouseDown 
    void OnMouseDown()
    {
        Buttons[0].GetComponent<Button>().onClick.AddListener(StartGame); // Start Button
        Buttons[1].GetComponent<Button>().onClick.AddListener(GameSettings); // Settings Button
        Buttons[2].GetComponent<Button>().onClick.AddListener(GameCredits); // Credits Button
        Buttons[3].GetComponent<Button>().onClick.AddListener(ExitGame); // Exit Button
        ReturnToMenuButton[0].GetComponent<Button>().onClick.AddListener(ReturnToMenu); // Settings Canvas
        ReturnToMenuButton[1].GetComponent<Button>().onClick.AddListener(ReturnToMenu); // Credits Canvas
    }
    #endregion

    #region Start
    void StartGame()
    {
        Debug.Log("Play");
    }
    #endregion

    #region Settings
    void GameSettings()
    {
        StartCoroutine(OpenSettings());
    }

    IEnumerator OpenSettings()
    {
        EnableStartingTransition();

        yield return new WaitForSeconds(2);

        MainMenu.SetActive(false);
        CanvasSettings.SetActive(true);

        EnableEndTransition();
    }

    public void SetVolume(float volume)
    {
        AudioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    #endregion

    #region Credits
    void GameCredits()
    {
        StartCoroutine(OpenCredits());
    }

    IEnumerator OpenCredits()
    {
        EnableStartingTransition();

        yield return new WaitForSeconds(2);

        MainMenu.SetActive(false);
        CanvasCredits.SetActive(true);

        EnableEndTransition();
    }
    #endregion

    #region ReturnMenu
    void ReturnToMenu()
    {
        StartCoroutine(OpenMenu());
    }

    IEnumerator OpenMenu()
    {
        EnableStartingTransition();

        yield return new WaitForSeconds(2);

        CanvasSettings.SetActive(false);
        CanvasCredits.SetActive(false);
        MainMenu.SetActive(true);

        EnableEndTransition();
    }
    #endregion

    #region Exit
    void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    #endregion

    #region Transition
    void EnableStartingTransition()
    {
        StartingTransition.SetActive(true);
        StartingTransition.GetComponent<Animator>().SetBool("Active", true);
        EndingTransition.SetActive(false);
    }

    void EnableEndTransition()
    {
        EndingTransition.SetActive(true);
        EndingTransition.GetComponent<Animator>().SetBool("Active", true);
        StartingTransition.SetActive(false);
    } 
    #endregion
    
    #endregion
}

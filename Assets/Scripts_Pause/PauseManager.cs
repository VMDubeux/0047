using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    #region Public Variables
    [Header("Array GameObjects:")]
    public GameObject[] Buttons;

    [Header("Canvas GameObject:")]
    public GameObject PauseMenu; 
    #endregion

    private bool _pauseEnabled = false;

    void Start()
    {
        PauseMenu.SetActive(false);
    }

    void Update()
    {
        OnMouseDown();
        EnablePauseMenu();
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
        Buttons[0].GetComponent<Animator>().SetBool("Active", false);
        Buttons[0].GetComponent<Animator>().SetBool("Inactive", true);
        Buttons[1].GetComponent<Animator>().SetBool("Active", false);
        Buttons[1].GetComponent<Animator>().SetBool("Inactive", true);
        Buttons[0].SetActive(false);
        Buttons[1].SetActive(false);
    } 
    #endregion

    void OpenMainMenu() 
    {
        
    }
}

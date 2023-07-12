using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    /// <Variables>

    /// <Public Variables>
    [Header("Canvas GameObjects:")]
    public GameObject MainMenu;
    public GameObject CanvasSettings;
    public GameObject CanvasCredits;
    public GameObject[] ReturnToMenuButton;

    public GameObject[] Buttons;

    public GameObject StartingTransition;
    public GameObject EndingTransition;

    /// <Private Readonly Variables>


    /// <Private Not Readonly Variables>


    /// <Methods>

    /// <Private Methods>

    void Start()
    {
        EnableEndTransition();
    }

    void Update()
    {
        OnMouseDown();
    }

    void OnMouseDown()
    {
        Buttons[0].GetComponent<Button>().onClick.AddListener(StartGame); // Start Button
        Buttons[1].GetComponent<Button>().onClick.AddListener(GameSettings); // Settings Button
        Buttons[2].GetComponent<Button>().onClick.AddListener(GameCredits); // Credits Button
        Buttons[3].GetComponent<Button>().onClick.AddListener(ExitGame); // Exit Button
        ReturnToMenuButton[0].GetComponent<Button>().onClick.AddListener(ReturnToMenu); // Settings Canvas
        ReturnToMenuButton[1].GetComponent<Button>().onClick.AddListener(ReturnToMenu); // Credits Canvas
    }

    void StartGame()
    {
        Debug.Log("Play");
    }

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

    void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

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

    /// <Public Methods>
}

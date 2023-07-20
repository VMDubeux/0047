using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject ReturnMenu;

    void Start()
    {
        AnimationEnd();
    }

    #region ButtonsAnimation

    public void AnimationStart()
    {
        GetComponent<Animator>().SetBool("Active", true);
        GetComponent<Animator>().SetBool("Inactive", false);
    }

    public void AnimationEnd()
    {
        GetComponent<Animator>().SetBool("Inactive", true);
        GetComponent<Animator>().SetBool("Active", false);
    }
    #endregion
}

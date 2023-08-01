using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    void Start()
    {
        StartingScene();
    }

    #region ButtonsAnimation

    public void StartingScene()
    {
        GetComponent<Animator>().SetBool("Inactive", false);
        GetComponent<Animator>().SetBool("Active", false);
    }

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

using Unity.VisualScripting;
using UnityEngine;

public class Buttons : MonoBehaviour
{
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

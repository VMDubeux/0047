using Unity.VisualScripting;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    /// <Methods>

    /// <Private Methods>
    void Start()
    {
        GetComponent<Animator>().SetBool("Inactive", true);
        GetComponent<Animator>().SetBool("Active", false);
    }

    /// <Public Methods>
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
}

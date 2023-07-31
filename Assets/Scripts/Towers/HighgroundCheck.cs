using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighgroundCheck : MonoBehaviour
{
    public bool hasTower = false;
    void Start()
    {
        hasTower = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void HasTower()
    {
        hasTower = true;
    }
}

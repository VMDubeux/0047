using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class CardSelection : MonoBehaviour
{
    bool fireCardSelected = false, waterCardSelected =  false, thunderCardSelected = false;
    RaycastHit hit;
    public Camera myCamera;
    public GameObject fireCardGO, waterCardGO, thunderCardGO;
    void Update()
    {
        Fire();
        Thunder();
        Water();
    }

    // Funcoes CANVAS
    public void FireCardSelected()
    {
        fireCardSelected = true;
    }

    public void ThunderCardSelected()
    {
        thunderCardSelected = true;
    }

    public void WaterCardSelected()
    {
        waterCardSelected = true;
    }
    // Funcoes extraidas
    private void Fire()
    {
        if (fireCardSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.CompareTag("Ground"))
                    {
                        Instantiate(fireCardGO, hit.point, Quaternion.identity);
                    }
                }
                fireCardSelected = false;
            }
        }
    }

    private void Thunder()
    {
        if (thunderCardSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.CompareTag("Ground"))
                    {
                        Instantiate(thunderCardGO, hit.point, Quaternion.identity);
                    }
                }
                thunderCardSelected = false;
            }
        }
    }
    private void Water()
    {
        if(waterCardSelected)
        {
            Instantiate(waterCardGO, new Vector3(0, 0, 200), Quaternion.identity);
        waterCardSelected= false;
        }
    }
}

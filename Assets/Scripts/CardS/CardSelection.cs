using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
public class CardSelection : MonoBehaviour
{
    bool fireCardSelected = false, waterCardSelected =  false, thunderCardSelected = false;
    public int cardPoints = 0, fireCost = 5, waterCost = 5, thunderCost = 5;
    RaycastHit hit;
    public Camera myCamera;
    public GameObject fireCardGO, waterCardGO, thunderCardGO;
    public TextMeshProUGUI cardPointsTMP, waterCostUI, fireCostUI, thunderCostUI;
    public Button waterButton, fireButton, thunderButton;
    private void Start() {
        fireCostUI.text = fireCost.ToString();
        waterCostUI.text = waterCost.ToString();
        thunderCostUI.text = thunderCost.ToString();
        cardPointsTMP.text = cardPoints.ToString();
    }
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
    // mudar valor do cardPoints no painel
    public void CardValueChange()
    {
        cardPointsTMP.text = cardPoints.ToString();
        // checar se pode usar a carta
        if(cardPoints >= waterCost)
        {
            waterButton.interactable = true;
        }
        else waterButton.interactable = false;

        if(cardPoints >= fireCost)
        {
            fireButton.interactable = true;
        }
        else fireButton.interactable = false;
        if(cardPoints >= thunderCost)
        {
            thunderButton.interactable = true;
        }
        else thunderButton.interactable = false;
    }
    // Funcoes extraidas
    private void Fire() // Carta de fogo
    {
        if (fireCardSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider)
                    {
                        Instantiate(fireCardGO, hit.point, Quaternion.identity);
                    }
                }
                fireCardSelected = false;
                cardPoints -= fireCost;
                CardValueChange();
                GetComponent<PlaceTowerHUD>().cardPanelGO.SetActive(false);
            }
        }
    }
    private void Thunder() // Carta de trovão
    {
        if (thunderCardSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider)
                    {
                        Instantiate(thunderCardGO, hit.point, Quaternion.identity);
                    }
                }
                thunderCardSelected = false;
                cardPoints -= thunderCost;
                CardValueChange();
                GetComponent<PlaceTowerHUD>().cardPanelGO.SetActive(false);
            }
        }
    }
    private void Water() // Carta de água
    {
        if(waterCardSelected)
        {
            Instantiate(waterCardGO, waterCardGO.transform.position, Quaternion.identity);
            waterCardSelected= false;
            cardPoints -= waterCost;
            CardValueChange();
            GetComponent<PlaceTowerHUD>().cardPanelGO.SetActive(false);
        }
    }

    public void CompareCardPoints()
    {
        cardPoints = GetComponent<PlaceTowerHUD>().cardPoints;
    }
}

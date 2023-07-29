using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlaceTowerHUD : MonoBehaviour
{
    bool tower0Selected = false, tower1Selected =  false, tower2Selected = false;
    public int cardPoints, tower0Cost = 5, tower1Cost = 5, tower2Cost = 5;
    public TextMeshProUGUI cardPointsTMP, tower1CostUI, tower0CostUI, tower2CostUI;
    public Button tower0Button, tower1Button, tower2Button;
    public GameObject cardPanelGO, towerPanelGO, useCardGO, placeTowerGO;
    private void Start() {
        tower0CostUI.text = tower0Cost.ToString();
        tower1CostUI.text = tower1Cost.ToString();
        tower2CostUI.text = tower2Cost.ToString();
        cardPointsTMP.text = cardPoints.ToString();
        cardPoints = GetComponent<CardSelection>().cardPoints;
    }
    void Update()
    {
        PlaceT0();
        PlaceT1();
        PlaceT2();
    }
    // Funcoes CANVAS
    public void Tower0Selected()
    {
        tower0Selected = true;
    }
    public void Tower1Selected()
    {
        tower1Selected = true;
    }
    public void Tower2Selected()
    {
        tower2Selected = true;
    }
    // mudar valor do cardPoints no painel
    public void CardValueChange()
    {
        cardPoints = GetComponent<CardSelection>().cardPoints;
        cardPointsTMP.text = cardPoints.ToString();
        // checar se pode usar a carta
        if(cardPoints >= tower1Cost)
        {
            tower0Button.interactable = true;
        }
        else tower0Button.interactable = false;

        if(cardPoints >= tower0Cost)
        {
            tower1Button.interactable = true;
        }
        else tower1Button.interactable = false;
        if(cardPoints >= tower2Cost)
        {
            tower2Button.interactable = true;
        }
        else tower2Button.interactable = false;
    }
    // Funcoes extraidas
    private void PlaceT0() // Torre 0
    {
        if (tower0Selected)
        {
            // colocar torre 0
            Debug.Log("Selected");
            CardValueChange();
            towerPanelGO.SetActive(false);
            tower0Selected = false;
        }
    }
    private void PlaceT1() // Torre 1 
    {
        if (tower1Selected)
        {
                        Debug.Log("Selected");
            // colocar torre 1 no mapa
            CardValueChange();
            towerPanelGO.SetActive(false);
            tower1Selected = false;
        }
    }
    private void PlaceT2 () // Torre 2 
    {
        if(tower2Selected)
        {
                        Debug.Log("Selected");
            // Colocar torre 2 no mapa
            CardValueChange();
            towerPanelGO.SetActive(false);
            tower2Selected = false;
        }
    }

    public void PlaceTower()
    {
        useCardGO.SetActive(true);
        placeTowerGO.SetActive(false);
        towerPanelGO.SetActive(true);
        cardPanelGO.SetActive(false);
    }

    public void CastCard()
    {
        placeTowerGO.SetActive(true);
        useCardGO.SetActive(false);
        cardPanelGO.SetActive(true);
        towerPanelGO.SetActive(false);
    }
}

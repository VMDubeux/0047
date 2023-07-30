using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    Animator myAnimator;
    CardSelection cardSelection;
    bool pickUp = false;
    private void Start() {
        myAnimator = GetComponent<Animator>();
        cardSelection = FindObjectOfType<CardSelection>().GetComponent<CardSelection>();
        myAnimator.SetTrigger("pickup");
        CardPickup();
        Destroy(gameObject, 3);
    }
    public void CardPickup()
    {
            // add bonus
            cardSelection.cardPoints++;
            cardSelection.CardValueChange();
            pickUp = true;      
    }
}

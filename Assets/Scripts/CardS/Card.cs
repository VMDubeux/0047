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
    }
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player") && !pickUp)
        {
            myAnimator.SetTrigger("pickup");
            // add bonus
            cardSelection.cardPoints++;
            cardSelection.CardValueChange();
            pickUp = true;
            // feedback de pickup
            Destroy(gameObject, 3);
        }
    }
}

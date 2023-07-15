using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    Animator myAnimator;
    CardSelection cardSelection;
    private void Start() {
        myAnimator = GetComponent<Animator>();
        cardSelection = FindObjectOfType<CardSelection>().GetComponent<CardSelection>();
    }
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            myAnimator.SetTrigger("pickup");
            // add bonus
            cardSelection.cardPoints++;
            cardSelection.CardValueChange();
            // feedback de pickup
            Destroy(gameObject, 3);
        }
    }
}

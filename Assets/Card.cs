using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    Animator myAnimator;
    private void Start() {
        myAnimator = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            myAnimator.SetTrigger("pickup");
            // add bonus
            // feedback de pickup
            Destroy(gameObject, 3);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUpMeteor : MonoBehaviour
{
    [SerializeField] private GameObject meteorGlow;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Meteor"))
        {
            Instantiate(meteorGlow, other.transform.position, meteorGlow.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}

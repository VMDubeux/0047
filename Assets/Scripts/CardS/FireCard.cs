using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCard : MonoBehaviour
{
    public int damage;
    public float colTimer = 1;
    BoxCollider myBoxCollider;

    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider>();
        Invoke("CollisionEnable", colTimer);
        Destroy(gameObject, 2);        
    }
    void Update()
    {
        
    }
private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
        Debug.Log("EnemyHit!"); 
        
        // Dano ao inimigo
        other.gameObject.GetComponent<EnemyStats>().myHealth = other.gameObject.GetComponent<EnemyStats>().myHealth - damage;
        other.gameObject.GetComponent<EnemyStats>().Hurt();
        // Ativar �rea de fogo
        }
    }

    void CollisionEnable()
    {
        myBoxCollider.enabled = true;
    }
}

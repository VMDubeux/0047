using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCard : MonoBehaviour
{
    public int damage;

    void Start()
    {
        Destroy(gameObject, 2);        
    }
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        if(other.CompareTag("Enemy"))
        {
        Debug.Log("EnemyHit!"); 
        
        // Dano ao inimigo
        other.GetComponent<EnemyStats>().myHealth = other.GetComponent<EnemyStats>().myHealth - damage;
        // Ativar área de fogo
        }
    }
}

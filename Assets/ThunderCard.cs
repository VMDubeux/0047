using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderCard : MonoBehaviour
{
    public int damage;

    void Start()
    {
        Destroy(gameObject, 6);
    }
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("EnemyHit!");

            // Dano ao inimigo
            collision.gameObject.GetComponent<EnemyStats>().myHealth = collision.gameObject.GetComponent<EnemyStats>().myHealth - damage;
            // Ativar �rea de fogo
        }
        
    }    
}

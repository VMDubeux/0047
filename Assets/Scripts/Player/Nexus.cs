using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : MonoBehaviour
{
    public int nexusHP;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
       gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        TowerTakeDamage(other);
    }

    void TowerTakeDamage(Collider other) //Torre tomando dano
    {
       
            if (other.CompareTag("Enemy"))
            {
                //Procurar parâmetro no inimigo 
                    int damage = other.GetComponent<EnemyStats>().myDamage;
                // Reduzir vida da torre
                    nexusHP -= damage;
                Destroy(other.gameObject);
            }

            if (nexusHP <= 0)
            {
                Destroy(gameObject);
            }
        
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Nexus : MonoBehaviour
{

    public float nexusHP, maxHP = 100;
    public Image nexusImage;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
       nexusHP = maxHP;
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
                nexusImage.fillAmount = nexusHP/maxHP;
                Destroy(other.gameObject);

            }

            if (nexusHP <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("Derrota");
            }
        
    }


}

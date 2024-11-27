using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;

    private int currentHealth;

    private void Start() {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage) { //Ouch!
        currentHealth -= damage;
        Debug.Log(currentHealth);
        DetectDeath();
    }

    private void DetectDeath() { //Ded yet?
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;

    private int currentHealth;
    private Knockback knockback;

    private void Awake() {
        knockback = GetComponent<Knockback>();
    }

    private void Start() {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage) { //Ouch!
        currentHealth -= damage;
        knockback.GetKnockedBack(PlayerController.Instance.transform, 15f);
        //Debug.Log(currentHealth);
        DetectDeath();
    }

    private void DetectDeath() { //Ded yet?
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }    
}

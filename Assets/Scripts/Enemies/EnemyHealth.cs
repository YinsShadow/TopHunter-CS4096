using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;

    private int currentHealth;
    private Knockback knockback;
    private Flash flash;

    private void Awake() {
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
    }

    private void Start() {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage) { //Ouch!
        currentHealth -= damage;
        knockback.GetKnockedBack(PlayerController.Instance.transform, 15f);
        //Debug.Log(currentHealth);
        StartCoroutine(flash.FlashRoutine());
    }

    public void DetectDeath() { //Ded yet?
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }    
}

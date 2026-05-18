using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{   
    //Set in Inspector, change the default health value as needed
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] FloatingHealthBar healthBar;

    private int currentHealth;
    private Knockback knockback;
    private Flash flash;

    private void Awake() {
        //Grabs components on startup
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }
    private void Start() {
        //Initialize health
        currentHealth = startingHealth;
        healthBar.UpdateHealthBar(currentHealth, startingHealth);
    }

    public void TakeDamage(int damage) {
        //Reduce health, knockback, and flash on hit
        healthBar.UpdateHealthBar(currentHealth, startingHealth);
        currentHealth -= damage;
        knockback.GetKnockedBack(PlayerController.Instance.transform,15f);
        StartCoroutine(flash.FlashRoutine());
    }

    public void DetectDeath() {

        //Destroy enemy if health runs out
        if (currentHealth <= 0) {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    public float maxHP = 100f;                 // Maximum HP
    public float flashDuration = 0.2f;         // Duration of the flash effect
    public Color flashColor = Color.red;       // Color to flash
    public GameObject[] damagingPrefabs;       // Array of damaging prefabs with trigger colliders

    public float currentHP;                   // Current HP
    private Renderer objectRenderer;           // Reference to the object's renderer
    private Color originalColor;               // Original color of the object
    private bool isFlashing = false;           // Flag to track if object is currently flashing
    public float damageAmount;


    private void Start()
    {
        currentHP = maxHP;                     // Initialize current HP to max HP
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
    }

    private void Update()
    {
        // Check if the object's HP has dropped to or below 0
        if (currentHP <= 0)
        {
            Destroy(gameObject); // Destroy the object or perform other actions
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject prefab in damagingPrefabs)
        { 
            if (other.CompareTag("PlayerAttack")) // Replace "Hurtbox" with the appropriate tag
            {
                TakeDamage(); // Decrease HP by a specified amount
                StartFlashEffect(); // Start the flash effect
            }
        }
    }

    private void TakeDamage()
    {
        currentHP -= damageAmount; // Decrease HP by the specified amount
    }

    private void StartFlashEffect()
    {
        if (!isFlashing)
        {
            StartCoroutine(FlashEffect());
        }
    }

    private IEnumerator FlashEffect()
    {
        isFlashing = true;
        Color originalColor = objectRenderer.material.color;

        objectRenderer.material.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        objectRenderer.material.color = originalColor;

        isFlashing = false;
    }

}

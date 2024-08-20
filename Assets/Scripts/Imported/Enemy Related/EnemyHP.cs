using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [Header("Main Health Value")]
    public float enemyHP;
    public float startingHP;

    [Header("Damage Feedback")]
    public float flashDuration = 0.2f;         // Duration of the flash effect
    public Color flashColor = Color.red;       // Color to flash
    private MeshRenderer objectRenderer;           // Reference to the object's renderer
    private Color originalColor;               // Original color of the object
    private bool isFlashing = false;           // Flag to track if object is currently flashing

    public void Start()
    {
        enemyHP = startingHP;
    }

    public void TakeDamage(float amount)
    {
        enemyHP -= amount;
        StartFlashEffect();
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

    private void Update()
    {
        if (enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}

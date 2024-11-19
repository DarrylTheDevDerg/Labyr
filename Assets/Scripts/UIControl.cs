using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [Header("UI Elements")]
    public Image crosshairImage; // The UI image for your crosshair.

    [Header("Crosshair Sprites")]
    public Sprite defaultCrosshair; // Default crosshair sprite.
    public Sprite interactableCrosshair; // Sprite for when looking at an Interactable.

    [Header("Raycast Settings")]
    public float rayDistance = 5f; // Distance for the ray to check.
    public LayerMask interactableLayer; // Layer mask to identify Interactable objects.
    public LayerMask interactableLayer2;

    private Camera mainCamera;
    private float origAlpha;

    void Start()
    {
        mainCamera = Camera.main;
        crosshairImage.sprite = defaultCrosshair; // Set default sprite at start.
        origAlpha = crosshairImage.color.a;
    }

    void Update()
    {
        UpdateCrosshair();
    }

    void UpdateCrosshair()
    {
        // Shoot a ray from the camera forward.
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;

        // Check if the ray hits an object in the Interactable layer.
        if (Physics.Raycast(ray, out hit, rayDistance, interactableLayer) || Physics.Raycast(ray, out hit, rayDistance, interactableLayer2))
        {
            // If we hit an interactable object, switch to the interactable crosshair.
            crosshairImage.sprite = interactableCrosshair;
            crosshairImage.color = new Color(1, 1, 1, 0.85f);
        }
        else
        {
            // If nothing in the Interactable layer is hit, use the default crosshair.
            crosshairImage.sprite = defaultCrosshair;
            crosshairImage.color = new Color(1, 1, 1, origAlpha);
        }
    }
}

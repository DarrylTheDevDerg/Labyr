using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("Player Health")]
    public float health = 10f;

    [Header("Player Invincibility Parameters")]
    public float invperiod = 1.5f;
    public float flashDuration = 0.2f;         // Duration of the flash effect
    public Color flashColor = Color.red;       // Color to flash
    private Renderer objectRenderer;           // Reference to the object's renderer
    private Color originalColor;               // Original color of the object
    private bool isFlashing = false;           // Flag to track if object is currently flashing
    public Color blinkColor;
    private float blinkDuration;
    private bool isBlinking = false;           // Flag to track if object is currently blinking

    [Header("Ammo Management")]
    public AmmoSystem ammoManagement;
    public ShootABullet shootingScript;
    public int currentAmmo;
    public int storedAmmo;
    public float gunCooldown;
    private bool inCooldown = false;
    public int secondGunUnlocked;

    [Header("Available Weapons")]
    public GameObject gun;
    public GameObject meleeWeapon;
    public GameObject unlockableWeapon;
    public int currentWeapon = 1;
    public float damage;
    public StabbyGoesTheKnife stabAnimation;

    [Header("Save Data")]
    public PlayerPrefsManager statController;
    public int points;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;

        blinkDuration = invperiod / 3;

        currentAmmo = statController.ammoUse;
        storedAmmo = statController.ammoExtra;
        secondGunUnlocked = statController.hasSecondWeapon;
        points = statController.points;
    }

    void Update()
    {

        currentAmmo = ammoManagement.currentAmmo;
        storedAmmo = ammoManagement.extraAmmo;

        // Gun function, autoshoot & management.
        if (currentWeapon == 1) // Gun
        { 
            gun.SetActive(true);
            meleeWeapon.SetActive(false);
            unlockableWeapon.SetActive(false);
            damage = (1.75f) * Random.Range(1f, 2.5f);

            if (Input.GetMouseButton(0) && currentAmmo > 0 && !inCooldown)
            {
                shootingScript.ShootNow();
                currentAmmo -= 1;
                ammoManagement.currentAmmo -= 1;
                ammoManagement.usedAmmo += 1;
                gunCooldown = 0.55f;

            }
            else
            {
                if (Input.GetMouseButton(0) && currentAmmo > 0 && !inCooldown)
                {
                    while (Input.GetMouseButtonDown(0))
                    {
                        shootingScript.ShootNow();
                        currentAmmo -= 1;
                        ammoManagement.currentAmmo -= 1;
                        ammoManagement.usedAmmo += 1;
                        gunCooldown = 0.55f;
                    }
                }
            }
        }

        if (currentWeapon == 2) // Knife
        {
            gun.SetActive(false);
            meleeWeapon.SetActive(true);
            unlockableWeapon.SetActive(false);
            damage = (2.75f) * Random.Range(0.9f, 1.2f);

            if (Input.GetMouseButton(0))
            {
                stabAnimation.StabbyStab();

            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    while (Input.GetMouseButtonDown(0))
                    {
                        stabAnimation.StabbyStab();
                    }
                }
            }
        }

        if (currentWeapon == 3 && secondGunUnlocked == 1) // Unlockable Gun
        {
            gun.SetActive(false);
            meleeWeapon.SetActive(false);
            unlockableWeapon.SetActive(true);
            damage = (5.75f) * Random.Range(0.9f, 1.2f);

            if (Input.GetMouseButton(0) && currentAmmo > 0 && !inCooldown)
            {
                shootingScript.ShootNow();
                currentAmmo -= 1;
                ammoManagement.currentAmmo -= 1;
                ammoManagement.usedAmmo += 1;
                gunCooldown = 0.72f;

            }
            else
            {
                if (Input.GetMouseButton(0) && currentAmmo > 0 && !inCooldown)
                {
                    while (Input.GetMouseButtonDown(0))
                    {
                        shootingScript.ShootNow();
                        currentAmmo -= 1;
                        ammoManagement.currentAmmo -= 1;
                        ammoManagement.usedAmmo += 1;
                        gunCooldown = 0.72f;
                    }
                }
            }
        }


        // Invincibility function.
        if (invperiod > 0)
        {
            StartBlinking();
            invperiod -= Time.deltaTime;
        }

        // No HP consequence
        if (health == 0 || health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        // Gun cooldown function.
        if (gunCooldown > 0)
        {
            inCooldown = true;
            gunCooldown -= Time.deltaTime;
        }
        else
        {
            inCooldown = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && !inCooldown)
        {
            currentWeapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && secondGunUnlocked == 1)
        {
            currentWeapon = 3;
        }
    }

    public void TakeFlatDamage(float damageTaken)
    {
        if (invperiod <= 0)
        {
            health -= damageTaken;
            StartFlashEffect();
            invperiod = 1.2f;
        }
        
    }

    private void StartFlashEffect()
    {
        if (!isFlashing && !isBlinking)
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

    private IEnumerator BlinkingColorEffect()
    {
        isBlinking = true;
        Color originalColor = objectRenderer.material.color;

        // Blinking loop
        while (isBlinking && invperiod > 0)
        {
            objectRenderer.material.color = blinkColor;
            yield return new WaitForSeconds(blinkDuration);

            objectRenderer.material.color = originalColor;
            yield return new WaitForSeconds(blinkDuration);
        }

        if (invperiod <= 0)
        {
            isBlinking = false;
        }

        objectRenderer.material.color = originalColor;
    }

    private void StartBlinking()
    {
        if (!isBlinking && !isFlashing)
        {
            StartCoroutine(BlinkingColorEffect());
        }
    }
}

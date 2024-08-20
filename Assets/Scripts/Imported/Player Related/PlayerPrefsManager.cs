using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    private int currentLevel;
    
    [Header("Essential")]
    public AmmoSystem ammoSystem;
    public PointSystem pointSystem;
    public PlayerController playerStats;

    [Header("Player Stats")]
    public int ammoUse;
    public int ammoExtra;
    public int points;
    public int medKits;
    public int hasSecondWeapon;


    private void Start()
    {
        // Load the current level from PlayerPrefs when the game starts
        LoadCurrentLevel();
        LoadPlayerStats();
    }

    public void SetCurrentLevel(int level)
    {
        // Set the current level in PlayerPrefs
        PlayerPrefs.SetInt("CurrentLevel", level);

        // Save the changes to PlayerPrefs
        PlayerPrefs.Save();

        // Update the local current level variable
        currentLevel = level;
    }

    public void SetSavedStats()
    {
        // Set the current level in PlayerPrefs
        if (!ammoSystem)
        {
            PlayerPrefs.SetInt("Ammo in Use", 100);
            PlayerPrefs.SetInt("Ammo Stored", 250);
        }
        else if (ammoSystem)
        {
            PlayerPrefs.SetInt("Ammo in Use", ammoSystem.currentAmmo);
            PlayerPrefs.SetInt("Ammo Stored", ammoSystem.extraAmmo);
        }
        
        if (!pointSystem)
        {
            PlayerPrefs.SetInt("Points", 0);
        }
        else if (pointSystem)
        {
            PlayerPrefs.SetInt("Points", pointSystem.amount);
        }

        // Save the changes to PlayerPrefs
        PlayerPrefs.Save();
    }

    public void LoadCurrentLevel()
    {
        // Load the current level from PlayerPrefs
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1); // Default level is 1 if not set
    }

    public void LoadPlayerStats()
    {
        // Load the current stats from PlayerPrefs
        if (!ammoSystem)
        {
            ammoExtra = PlayerPrefs.GetInt("Ammo Stored", 250);
            ammoUse = PlayerPrefs.GetInt("Ammo in Use", 100);
        }
        else if (ammoSystem)
        {
            ammoSystem.currentAmmo = PlayerPrefs.GetInt("Ammo in Use", 100); // Default level is 1 if not set
            ammoSystem.extraAmmo = PlayerPrefs.GetInt("Ammo Stored", 250);
        }

        if (!pointSystem)
        {
            points = PlayerPrefs.GetInt("Points", 0);
        }
        else if (pointSystem)
        {
            pointSystem.amount = PlayerPrefs.GetInt("Points", 0);
        }
    }

    public int GetCurrentLevel()
    {
        // Retrieve the current level
        return currentLevel;
    }

    public void SavePrefs()
    {
        PlayerPrefs.Save();
    }

    public void LoadLevelScene()
    {
        if (currentLevel == 1)
        {
            SceneManager.LoadScene("LVL1");
        }

        if (currentLevel == 2)
        {
            SceneManager.LoadScene("LVL2");
        }

        if (currentLevel == 3)
        {
            SceneManager.LoadScene("LVL3");
        }
    }
}

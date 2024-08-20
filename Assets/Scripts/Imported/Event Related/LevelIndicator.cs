using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelIndicator : MonoBehaviour
{
    public TextMeshProUGUI levelIndicator;
    public PlayerPrefsManager saveData;

    // Start is called before the first frame update
    void Start()
    {
        if (saveData.GetCurrentLevel() == 1)
        {
            levelIndicator.SetText("Area 1");
        }

        if (saveData.GetCurrentLevel() == 2)
        {
            levelIndicator.SetText("Area 2");
        }

        if (saveData.GetCurrentLevel() == 3)
        {
            levelIndicator.SetText("Final Area");
        }

        if (saveData.GetCurrentLevel() == 0)
        {
            levelIndicator.SetText("null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] names = new string[5];

    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        CheckText(names);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckText(string[] array)
    {
        foreach (string s in array)
        {
            if (s == sceneName)
            {
                if (sceneName == "Lv 1")
                {
                    text.text = "The Grass Maze";
                }

                else if (sceneName == "Lv 2")
                {
                    text.text = "The Pit";
                }

                else if (sceneName == "Lv 3")
                {
                    text.text = "The Beginning";
                }

                else if (sceneName == "Lv 4")
                {
                    text.text = "The End";
                }

                else if (sceneName == "Tutorial")
                {
                    text.text = "Tutorial";
                }

                else
                {
                    text.text = "Bonus Level";
                }
            }
        }
    }
}

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
            switch (s + sceneName)
            {
                case string when sceneName == "Lv 1" && s == sceneName:
                    text.text = s;
                    break;

                case string when sceneName == "Lv 2" && s == sceneName:
                    text.text = s;
                    break;

                case string when sceneName == "Lv 3" && s == sceneName:
                    text.text = s;
                    break;

                case string when sceneName == "Lv 4" && s == sceneName:
                    text.text = s;
                    break;

                case string when sceneName == "Tutorial" && s == sceneName:
                    text.text = s;
                    break;

                default:
                    text.text = "Bonus Level!";
                    break;
            }
        }
    }
}

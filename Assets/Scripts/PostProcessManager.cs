using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PostProcessManager : MonoBehaviour
{
    public TextMeshProUGUI optionText;

    private int language;
    private Options options;
    private Volume cam;
    private bool effect;

    // Start is called before the first frame update
    void Start()
    {
        options = FindObjectOfType<Options>();
        cam = FindObjectOfType<Volume>();

        effect = cam.enabled;
        language = options.lang;

        Manager();
    }

    private void Update()
    {
        effect = cam.enabled;
        language = PlayerPrefs.GetInt("Idioma", 0);

        Manager();
    }

    public void Manager()
    {
        if (effect)
        {
            switch (language)
            {
                case 0:
                    optionText.text = "Sí";
                    break;

                case 1:
                    optionText.text = "Yes";
                    break;
            }
        }
        else
        {
            optionText.text = "No";
        }
    }
}

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
        language = options.lang;

        Manager();
    }

    public void Manager()
    {
        if (effect)
        {
            if (language == 0)
            {
                optionText.text = "Sí";
            }
            
            if (language == 1)
            {
                optionText.text = "Yes";
            }
        }

        if (!effect)
        {
            optionText.text = "No";
        }
    }
}

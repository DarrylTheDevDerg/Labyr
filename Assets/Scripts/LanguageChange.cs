using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class LanguageChange : MonoBehaviour
{
    private TextMeshProUGUI text;
    [TextArea]
    public string[] languageStrings;
    private int langSetting;

    private void Start()
    {
        langSetting = PlayerPrefs.GetInt("Idioma", 0);
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = languageStrings[langSetting];
        LanguageUpdate();
    }

    public void AddLanguage()
    {
        langSetting++;

        if (langSetting >= languageStrings.Length)
        {
            langSetting = 0;
        }

        PlayerPrefs.SetInt("Idioma", langSetting);
    }

    public void SetLanguage(int value)
    {
        langSetting = value;

        if (langSetting >= languageStrings.Length)
        {
            langSetting = languageStrings.Length - 1;
        }

        PlayerPrefs.SetInt("Idioma", value);
    }

    public void LanguageUpdate()
    {
        langSetting = PlayerPrefs.GetInt("Idioma", 0);
    }
}

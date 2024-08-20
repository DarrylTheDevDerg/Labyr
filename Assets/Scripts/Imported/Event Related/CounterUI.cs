using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterUI : MonoBehaviour
{
    public TextMeshProUGUI counterText; // Reference to the TextMeshPro UI element
    public MonoBehaviour valueScript;   // Reference to the script with the value you want to display
    public string valuePropertyName;    // Name of the property or field holding the value

    private void Update()
    {
        // Update the TextMeshPro text with the value from the referenced script
        counterText.text = Mathf.RoundToInt(GetValueFromScript()).ToString();
    }

    private float GetValueFromScript()
    {
        System.Type scriptType = valueScript.GetType();
        System.Reflection.FieldInfo field = scriptType.GetField(valuePropertyName);
        if (field != null)
        {
            return (float)field.GetValue(valueScript);
        }

        System.Reflection.PropertyInfo property = scriptType.GetProperty(valuePropertyName);
        if (property != null)
        {
            return (float)property.GetValue(valueScript);
        }

        return 0f;
    }
}

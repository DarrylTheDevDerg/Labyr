using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterNumericUI : MonoBehaviour
{
    public TextMeshProUGUI counterText; // Reference to the TextMeshPro UI element
    public AmmoSystem ammoSystem;      // Reference to the AmmoSystem script
    public PlayerController playerController; // Reference to the PlayerController script

    public string ammoValueField = "ammo";      // Name of the field to retrieve ammo value
    public string playerValueField = "health";  // Name of the field to retrieve player's value

    public bool usePlayerValue = true; // Flag to choose between player and ammo values

    private void Update()
    {
        // Update the TextMeshPro text with the specified values as whole numbers
        counterText.text = GetFormattedValue();
    }

    private string GetFormattedValue()
    {
        // Retrieve the values based on the specified fields
        int value = usePlayerValue
            ? GetNumericValue<int>(playerController, playerValueField)
            : GetNumericValue<int>(ammoSystem, ammoValueField);

        // Format the value into a string as a whole number
        string formattedValue = usePlayerValue
            ? $"{value}"
            : $"{value}";

        return formattedValue;
    }

    private T GetNumericValue<T>(MonoBehaviour script, string fieldName)
    {
        // Use reflection to access the specified field or property
        System.Type scriptType = script.GetType();

        // Check if the field exists in the script
        System.Reflection.FieldInfo field = scriptType.GetField(fieldName);
        if (field != null)
        {
            // Try to cast the value to the specified type (T)
            try
            {
                return (T)field.GetValue(script);
            }
            catch (System.InvalidCastException)
            {
                Debug.LogError($"InvalidCastException: Field '{fieldName}' is not of type {typeof(T)} in {script.GetType().Name}");
            }
        }

        // Check if the property exists in the script
        System.Reflection.PropertyInfo property = scriptType.GetProperty(fieldName);
        if (property != null)
        {
            // Try to cast the value to the specified type (T)
            try
            {
                return (T)property.GetValue(script);
            }
            catch (System.InvalidCastException)
            {
                Debug.LogError($"InvalidCastException: Property '{fieldName}' is not of type {typeof(T)} in {script.GetType().Name}");
            }
        }

        return default(T);
    }
}

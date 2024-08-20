using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSliderControl : MonoBehaviour
{
    public Slider hpUI;
    public PlayerController pc;
    public float maxHeath;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = pc.health;
        UpdateHpUI();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = pc.health;
        UpdateHpUI();
    }

    public void UpdateHpUI()
    {
        hpUI.value = (currentHealth / maxHeath)*100;
    }
}

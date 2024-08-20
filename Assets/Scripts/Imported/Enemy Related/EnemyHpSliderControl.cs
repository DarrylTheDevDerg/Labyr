using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpSliderControl : MonoBehaviour
{
    public Slider hpUI;
    public DamageableObject enemyHP;
    public float maxHeath;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyHP.maxHP;
        UpdateEnemyHpUI();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = enemyHP.currentHP;
        UpdateEnemyHpUI();
    }

    public void UpdateEnemyHpUI()
    {
        hpUI.value = (currentHealth / maxHeath)*100;
    }
}

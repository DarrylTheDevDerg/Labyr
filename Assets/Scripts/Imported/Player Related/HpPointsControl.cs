using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpPointsControl : MonoBehaviour
{
    public List<Image> hpUI;
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
        for (int i = 0; i < hpUI.Count; i++)
        {
            if(currentHealth > i)
            {
                hpUI[i].gameObject.SetActive(true);
            }
            else
            {
                hpUI[i].gameObject.SetActive(false);
            }
        }
    }
}

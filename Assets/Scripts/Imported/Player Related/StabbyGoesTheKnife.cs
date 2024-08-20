using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabbyGoesTheKnife : MonoBehaviour
{
    [Header("Necessary stuff")]
    public GameObject knifePrefab;
    public PlayerController weaponCheck;
    public Animator animationManager;
    public string animatorTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StabbyStab()
    {
        if (weaponCheck.currentWeapon == 2)
        { 
            animationManager.SetTrigger(animatorTrigger);
        }
    }
}

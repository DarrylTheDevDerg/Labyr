using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSystem : MonoBehaviour
{
    public int currentAmmo;
    public int extraAmmo;
    public int usedAmmo;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo <= 999)
        {
            if (extraAmmo > usedAmmo)
            { 
                currentAmmo += usedAmmo;
                extraAmmo -= usedAmmo;
                usedAmmo = 0;
            }
        }
    }

    public void AddAmountAmmo(int number)
    {
        if (currentAmmo < 999)
        {
            currentAmmo += number;
        }
        else
        {
            extraAmmo += number;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SanityLife : MonoBehaviour
{
    [Header("Display")]
    public int displayLife;
    public TextMeshProUGUI displayLifeText;

    private int trueLife;
    private int storedPoison;

    [Header("Lose Related Stuff")]
    public int loseRate;
    public string gameOverScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

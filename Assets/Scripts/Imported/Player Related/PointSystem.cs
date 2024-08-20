using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointSystem : MonoBehaviour
{
    [SerializeField] PlayerController playerInGame;
    public UnityEvent[] ui;
    public int amount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint()
    {
        playerInGame.points += amount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        AddPoint();
        for (int i = 0; i < ui.Length; i++)
        {
            ui[i].Invoke();
        }
        Destroy(gameObject);
    }
}

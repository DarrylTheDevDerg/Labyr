using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDefeatCount : MonoBehaviour
{
    public UnityEvent[] actionsUponDestruction;
    public int enemyCount = 0;
    //public int enemyThreshold;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 0;
    }

    // Update is called once per frame
    //void Update()
    //{
        //if (enemyCount >= enemyThreshold)
        //{
            //for (int i = 0; i < actionsUponDestruction.Length; i++)
            //{
                //actionsUponDestruction[i].Invoke();
            //}
        //}
    //}
}

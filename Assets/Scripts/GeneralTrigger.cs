using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GeneralTrigger : MonoBehaviour
{
    public string player;
    public UnityEvent stuff;
    public bool timed;
    public float timeEnd;

    private float time;

    private void OnTriggerStay(Collider other)
    {
        if (timed)
        {
            time += Time.deltaTime;
        }

        if (time > timeEnd)
        {
            stuff.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(player))
        {
            stuff.Invoke();
        }
    }

    public void Punishment()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

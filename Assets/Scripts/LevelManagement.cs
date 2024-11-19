using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour
{
    public string[] prefNames;
    public int[] prefValues;
    public string[] scenes;

    public Action[] actions;

    public enum Action 
    {
        Modify,
        Warp
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActionRealization(Action act)
    {
        switch (act)
        {
            case Action.Modify:
                foreach (var pref in prefNames)
                {
                    foreach (var prefValue in prefValues)
                    {
                        PlayerPrefs.SetInt(pref, prefValue);
                    }
                }
                break;

            case Action.Warp:
                int warp = PlayerPrefs.GetInt("Level", 0);

                SceneManager.LoadScene(scenes[warp]);
                break;
        }
    }

    public void DoActionCheck()
    {
        foreach (var act in actions)
        {
            ActionRealization(act);
        }
    }
}

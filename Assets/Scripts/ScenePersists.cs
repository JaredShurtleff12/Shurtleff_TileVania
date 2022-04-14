using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersists : MonoBehaviour
{
    void Awake()
    {
        int intNumScenePersists = FindObjectsOfType<ScenePersists>().Length;
        if(intNumScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelÜbergreifend : MonoBehaviour
{
    void Awake()
    {
        int numLevelÜbergreifend = FindObjectsOfType<LevelÜbergreifend>().Length;
        if (numLevelÜbergreifend > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetLevelÜbergreifend()
    {
        Destroy(gameObject);
    }
}

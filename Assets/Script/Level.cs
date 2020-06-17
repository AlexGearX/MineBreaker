using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Parameters

    [SerializeField] int breakableblocks; // Serialized for debugging purposes


    // Cached reference

    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breakableblocks++;
    }

    public void BlockDestroy()
    {
        breakableblocks--;

        if (breakableblocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }
}

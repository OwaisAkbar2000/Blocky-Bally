using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //parameters
    [SerializeField] int BreakableBlocks; //seriallized field debugging purpose

    //cached Ref.
    SceneLoader sceneloader;

    public void Start()
    {
        sceneloader = FindAnyObjectByType<SceneLoader>();
    }

    public void CountBlocks()
    {
       BreakableBlocks++;
    }

    public void BlockDestroyed()
    {
        BreakableBlocks--;
        if (BreakableBlocks <= 0 )
        {
            sceneloader.LoadNextScene();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StandardPortalTeleportPlayertoNextScene : InteractiveObject
{
    [SerializeField]
    private string scenetoLoad;

    public override void InteractWith()
    {
        base.InteractWith();
        SceneManager.LoadScene(scenetoLoad);
    }
}


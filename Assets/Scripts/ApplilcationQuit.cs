using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplilcationQuit : InteractiveObject
{
   public override void InteractWith()
    {
        base.InteractWith();
        Application.Quit();
        Debug.Log("Player quit the game");
    }
}

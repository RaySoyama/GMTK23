using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Willow.IDLUI;


public class MechBoltButton : IDLUIButton.Extension
{
    public MechTask mechTask;
    protected override void OnSelect()
    {
        //do thing, play anim, play sound, idk
        Destroy(gameObject);
    }

    protected override void OnButtonDisabled()
    {
        mechTask.boltButtons.Remove(this);
    }
}

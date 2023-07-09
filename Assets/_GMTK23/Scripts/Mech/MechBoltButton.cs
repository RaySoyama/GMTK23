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
        mechTask.OnBoltClicked(this);
    }
}

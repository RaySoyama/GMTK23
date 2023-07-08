using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Willow.Library;
using Willow.IDLUI;
public class MenuHighlight : IDLUIButton.Extension
{


    float target = 1f;
    float brightness = 1f;

    new Renderer renderer;

    private void Start()
    {
        this.Populate(ref renderer);
    }

    private void Update()
    {
        if (brightness == target)
            return;
        if (brightness < target)
            brightness = target;
        else
            brightness = Maths.Damp(brightness, target, 7f);

        renderer.material.SetFloat("_Scalar2", brightness);
    }

    protected override void OnSelect()
    {
        brightness = 6f;
    }

    protected override void OnGainFocus()
    {
        target = 2f;
    }

    protected override void OnLoseFocus()
    {
        target = 1f;
    }
}

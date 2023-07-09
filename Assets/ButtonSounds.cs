using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Willow.Library;
using Willow.IDLUI;

public class ButtonSounds : IDLUIButton.Extension
{
    AudioSource source;
    public AudioClip[] clips;
    private int last = 0;
    void Start()
    {
        this.Populate(ref source);
    }

    // Update is called once per frame
    protected override void OnSelect()
    {
        last = last.RandomExcluding(clips.Length);
        source.PlayOneShot(clips[last]);
    }
}

public static class UtilityClassAKAIfRayFindsThisHesGunnaBeMad
{
    public static int RandomExcluding(this int value, int maxExclusive)
    {
        int rand = Random.Range(0, maxExclusive - 1);
        if (rand >= value)
            rand++;
        return rand;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Willow.Library;
public class VolumeText : MonoBehaviour
{
    public UnityEngine.Audio.AudioMixer mixer;
    public string property;
    public string prefix;
    int steps = 10;
    int current = 10;
    public void Adjust (int delta)
    {
        current += delta;
        current = Mathf.Clamp(current, 0, steps);

        mixer.SetLinearVolume(property, current / (float)steps);
        GetComponent<Tatting.MeshText>().Text = prefix + current;
    }
}

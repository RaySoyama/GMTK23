using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCycler : MonoBehaviour
{
[SerializeField]
private List<Animator> animators;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("l"))
        {
foreach(Animator a in animators)
{
a.SetInteger("PosInQueue",a.GetInteger("PosInQueue") - 1);

}
        }
    }
}

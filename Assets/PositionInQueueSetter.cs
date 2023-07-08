using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionInQueueSetter : MonoBehaviour
{
    [SerializeField]
    private Animator a;

    public int posInQueue;

    // Start is called before the first frame update
    void Start()
    {
        a.SetInteger("PosInQueue",posInQueue);

        a.SetTrigger("init");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

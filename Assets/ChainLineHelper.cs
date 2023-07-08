using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLineHelper : MonoBehaviour
{
    [SerializeField] 
    private LineRenderer lr;

        [SerializeField] 
    private Transform top, bot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, top.position);
        lr.SetPosition(1, bot.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechAnimEvents : MonoBehaviour
{
    [SerializeField]
    private SpringJoint sj;

    private float targetHeight = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

          sj.connectedAnchor = Vector3.Lerp(sj.connectedAnchor, new Vector3(0, -targetHeight, 0), Time.deltaTime * 0.5f);
        
    }

    void SetSpringHeight(float height)
    {
        targetHeight = height;

    }
}

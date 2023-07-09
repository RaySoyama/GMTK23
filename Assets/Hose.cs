using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hose : MonoBehaviour
{
    [SerializeField]
    private SpringJoint sj;

    [SerializeField]
    private Transform head, hole;

    [SerializeField]
    private Animator a;


    private float targetHeight = 5;

    public float endHeight = 0;

    public Vector3 rotOffset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        sj.connectedAnchor = Vector3.Lerp(sj.connectedAnchor, new Vector3(0, -targetHeight, 0), Time.deltaTime * 3f);

        if (Input.GetKeyDown("k"))
        {
            Connect();
        }

        if (Input.GetKeyDown("j"))
        {
            a.SetTrigger("drop");
        }

        if (Input.GetKeyDown("h"))
        {
            a.SetTrigger("retract");
        }

    }

    void SetSpringHeight(float height)
    {
        targetHeight = height;

    }

    void Connect()
    {
        head.position = hole.position;
        head.rotation = hole.rotation;
        head.Rotate(rotOffset);
        sj.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Pump()
    {
        sj.GetComponent<MeshRenderer>().materials[1].SetFloat("_Pumping", 1);
    }

    void Drop()
    {
        targetHeight = endHeight;
        sj.GetComponent<Rigidbody>().AddForce(Vector3.forward * 0.1f);
    }

    void Retract()
    {
        targetHeight = 5;
        sj.GetComponent<Rigidbody>().AddForce(Vector3.forward * 0.1f);
    }
}

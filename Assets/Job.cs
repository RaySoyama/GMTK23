using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Job : MonoBehaviour
{
    public int interactionCount = 8;

    public int interactionsThisPhase = 0;

    public int thisPhase = 0;

    public Transform newPanel;

    public MiddleFingerManager MFM;

    public int jobIndex;

    public int cameraIndex;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (interactionCount == interactionsThisPhase)
        {
            interactionsThisPhase = 0;
            thisPhase++;

            if (newPanel)
            {
                newPanel.GetComponent<MeshRenderer>().material = MFM.repairPartMat;
                newPanel.GetComponent<ParticleSystem>().Play();

                MFM.JobComplete(jobIndex);

                foreach (Button b in this.transform.GetComponentsInChildren<Button>())
                {

                    if (b.GetComponent<BoltRef>())
                    {
                        b.GetComponent<BoltRef>().bolt.transform.GetComponent<MeshRenderer>().enabled = true;
                        b.GetComponent<BoltRef>().bolt.transform.GetComponent<MeshRenderer>().material = MFM.repairPartMat;
                    }


                }

            }
        }
        //Spawn new Thing or wait to pump


    }

    public void Interact(Transform t)
    {
        if (t.GetComponent<BoltRef>())
        {
            t.GetComponent<Button>().enabled = false;

            {
                interactionsThisPhase++;
            }

            t.GetComponent<BoltRef>().bolt.transform.GetComponent<ParticleSystem>().Play();
            t.GetComponent<BoltRef>().bolt.transform.GetComponent<MeshRenderer>().enabled = false;
        }


    }

}

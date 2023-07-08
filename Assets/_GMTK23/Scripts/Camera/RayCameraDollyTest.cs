using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class RayCameraDollyTest : MonoBehaviour
{
    public CinemachineVirtualCamera vcam1;
    public CinemachineVirtualCamera vcam2;
    private CinemachineTrackedDolly vcamDolly1;
    private CinemachineTrackedDolly vcamDolly2;

    [Range(1.0f, 10.0f)]
    public float timeToDolly = 4;

    private void Start()
    {
        vcamDolly1 = vcam1.GetCinemachineComponent<CinemachineTrackedDolly>();
        vcamDolly2 = vcam2.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Fuck());
        }
    }

    private IEnumerator Fuck()
    {
        float i = 0;

        vcam1.Priority = 10;
        vcam2.Priority = 0;

        while (i < 1.0f)
        {
            vcamDolly1.m_PathPosition = i;
            i += Time.deltaTime / timeToDolly;
            yield return null;
        }

        i = 0;
        vcam1.Priority = 0;
        vcam2.Priority = 10;

        while (i < 1.0f)
        {
            vcamDolly2.m_PathPosition = i;
            i += Time.deltaTime / timeToDolly;
            yield return null;
        }
    }
}

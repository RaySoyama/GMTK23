using UnityEngine;
using Cinemachine;
using System.Collections.Generic;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    [System.Serializable]
    public struct DollyTime
    {
        public CinemachineVirtualCamera VCam;
        public float timeToLerp;
    }

    [SerializeField]
    private CinemachineVirtualCamera defaultVCam;

    [SerializeField]
    private List<DollyTime> fuelDollys;


    private Coroutine currentDollyCour = null;

    private void Start()
    {
        ResetAllVCamPriorities();
        defaultVCam.Priority = 99;
    }

    [ContextMenu("Return to Default")]
    public void ReturnToDefault()
    {
        //fade screen?
        ResetAllVCamPriorities();
        defaultVCam.Priority = 99;
    }

    [ContextMenu("Dolly To Fuel")]
    public void DollyToFuel()
    {
        if (currentDollyCour == null)
        {
            currentDollyCour = StartCoroutine(DollyLerp(fuelDollys));
        }
        else
        {
            Debug.LogWarning("Trying to multi-track dolly :(");
        }
    }

    private void ResetAllVCamPriorities()
    {
        ResetVCamPriorities(fuelDollys);
    }
    private void ResetVCamPriorities(List<DollyTime> dollyTimes)
    {
        foreach (DollyTime DT in dollyTimes)
        {
            DT.VCam.Priority = 0;
        }
    }

    private IEnumerator DollyLerp(List<DollyTime> dollyTimes)
    {
        float i = 0;
        int prio = 0;

        foreach (DollyTime DT in dollyTimes)
        {
            DT.VCam.Priority = 100 + prio;
            prio++; //lol

            CinemachineTrackedDolly dolly = DT.VCam.GetCinemachineComponent<CinemachineTrackedDolly>();
            dolly.m_PositionUnits = CinemachinePathBase.PositionUnits.Normalized;
            dolly.m_PathPosition = 0f;
            while (i < 1.0f)
            {
                dolly.m_PathPosition = i;
                i += Time.deltaTime / DT.timeToLerp;
                yield return null;
            }

            dolly.m_PathPosition = 1f;
        }

        currentDollyCour = null;
    }
}
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

    public static CameraManager instance
    {
        get
        {
            return _instance;
        }
    }
    private static CameraManager _instance;

    [SerializeField]
    private CinemachineVirtualCamera defaultVCam;

    [ReadOnlyField]
    public List<List<DollyTime>> AllTaskDollys;

    private Coroutine currentDollyCour = null;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.LogError("Can't make multiple singletons of same type");
            Destroy(this);
            return;
        }

        AllTaskDollys = new List<List<DollyTime>>();
    }
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

    public void DollyToTask(List<DollyTime> taskDollys)
    {
        if (currentDollyCour == null)
        {
            currentDollyCour = StartCoroutine(DollyLerp(taskDollys));
        }
        else
        {
            Debug.LogWarning("Trying to multi-track dolly :(");
        }
    }

    private void ResetAllVCamPriorities()
    {
        foreach (var TD in AllTaskDollys)
        {
            ResetVCamPriorities(TD);
        }
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
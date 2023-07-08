using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechTask : MonoBehaviour
{
    public enum MechTaskType
    {
        unset = 0,
        panel = 1
    }

    [field: SerializeField]
    public MechTaskType TaskType { get; private set; }

    [field: SerializeField]
    public Transform taskTransform { get; private set; }

    [SerializeField]
    private List<CameraManager.DollyTime> dollys;

    [Space(10), Header("Panel Components")]
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private List<GameObject> bolts;

    private void OnEnable()
    {
        CameraManager.instance.AllTaskDollys.Add(dollys);
    }
    private void OnDisable()
    {
        CameraManager.instance.AllTaskDollys.Remove(dollys);
    }
    public void MoveCameraToTask()
    {
        CameraManager.instance.DollyToTask(dollys);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechTaskManager : MonoBehaviour
{
    public static MechTaskManager instance
    {
        get
        {
            return _instance;
        }
    }
    private static MechTaskManager _instance;

    [SerializeField, ReadOnlyField]
    private List<MechTask> AllTasks;

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
    }

    private void Start()
    {
        AllTasks = new List<MechTask>(GetComponentsInChildren<MechTask>());
    }
}
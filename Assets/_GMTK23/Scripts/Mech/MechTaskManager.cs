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

    [field: SerializeField, ReadOnlyField]
    public List<MechTask> AllTasks { get; set; }

    [field: SerializeField, ReadOnlyField]
    public List<MechTaskButton> AllTaskButtons { get; set; }

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

    public void DisableAllButtons()
    {
        foreach (var button in AllTaskButtons)
        {
            button.HideButton();
        }
    }

    public void EnableAllButtons()
    {
        foreach (var button in AllTaskButtons)
        {
            button.ShowButton();
        }
    }
}
using Willow.IDLUI;
using UnityEngine;

public class MechTaskButton : IDLUIButton.Extension
{
    [SerializeField, ReadOnlyField]
    private MechTask mechTask;

    [SerializeField, ReadOnlyField]
    private LineRenderer lineRenderer;

    private void Start()
    {
        mechTask = GetComponentInParent<MechTask>();
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, mechTask.taskTransform.position);
    }

    protected override void OnButtonEnabled()
    {
        MechTaskManager.instance.AllTaskButtons.Add(this);
    }
    protected override void OnButtonDisabled()
    {
        MechTaskManager.instance.AllTaskButtons.Remove(this);
    }

    protected override void OnSelect()
    {
        mechTask.MoveCameraToTask();
        MechTaskManager.instance.DisableAllButtons();
    }
}

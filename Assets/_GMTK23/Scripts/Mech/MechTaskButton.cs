using Willow.IDLUI;
using UnityEngine;

public class MechTaskButton : IDLUIButton.Extension
{
    [SerializeField, ReadOnlyField]
    private MechTask mechTask;

    [SerializeField, ReadOnlyField]
    private LineRenderer lineRenderer;

    [SerializeField, ReadOnlyField]
    private MeshRenderer meshRenderer;
    private void Start()
    {
        mechTask = GetComponentInParent<MechTask>();
        lineRenderer = GetComponent<LineRenderer>();
        meshRenderer = GetComponent<MeshRenderer>();

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

    public void HideButton()
    {
        meshRenderer.enabled = false;
        lineRenderer.enabled = false;
    }
    public void ShowButton()
    {
        meshRenderer.enabled = true;
        lineRenderer.enabled = true;
    }

}

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

    protected override void OnSelect()
    {
        //do thing
    }
}

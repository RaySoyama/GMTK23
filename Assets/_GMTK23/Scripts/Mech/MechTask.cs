using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechTask : MonoBehaviour
{
    public enum MechTaskType
    {
        unset = 0,
        panel = 1,
        fuel = 2
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
    [ReadOnlyField]
    public List<MechBoltButton> boltButtons;

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
        PrepareTask();
    }

    private void PrepareTask()
    {
        switch (TaskType)
        {
            case MechTaskType.unset:
                throw new NotImplementedException();
            //break;
            case MechTaskType.panel:
                PreparePanelTask();
                break;
            case MechTaskType.fuel:
                break;
        }
    }

    private void PreparePanelTask()
    {
        boltButtons = new List<MechBoltButton>();

        foreach (var bolt in bolts)
        {
            var bltBtn = bolt.AddComponent<MechBoltButton>();
            var bltBtnBUTTON = bltBtn.GetComponent<Willow.IDLUI.IDLUIButton>();

            if (bolt.TryGetComponent<MeshFilter>(out MeshFilter filter))
            {
                bltBtnBUTTON.bounds = filter.sharedMesh.bounds;
            }

            boltButtons.Add(bltBtn);
            bltBtn.mechTask = this;
        }
    }

    public void OnBoltClicked(MechBoltButton boltButton)
    {
        //should check if its actually in the list but eh
        boltButtons.Remove(boltButton);
        bolts.Remove(boltButton.gameObject);
        Destroy(boltButton.gameObject);

        if (boltButtons.Count == 0)
        {
            //game done, go back to default camera.
            //enable buttons again
            Debug.Log("Minigame done, do thing");
            CameraManager.instance.ReturnToDefault();
            MechTaskManager.instance.EnableAllButtons();
        }
    }

}

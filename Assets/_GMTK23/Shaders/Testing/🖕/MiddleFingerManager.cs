using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleFingerManager : MonoBehaviour
{
    public List<Camera> jobCameras;
    public List<Animator> jobCamAnimators;
    public List<bool> isJobCompleteOrActive;
    public List<bool> isJobComplete;
    public List<Camera> activeJobCameras;
    public List<Vector4> jobCamLayoutPositions;
    public List<bool> activeJobCamLayoutPositions;

    public Material repairPartMat;

    private int completedJobs = 0;

    // Start is called before the first frame update
    void Start()
    {
        AssignCamsAtStart();
    }

    // Update is called once per frame
    void Update()
    {
        //If there is an open active camera slot fill it
        if (activeJobCameras.Count < 5 && completedJobs <= 4)
        {
            for (int i = 0; i < jobCameras.Count; i++)
            {
                if (jobCameras[i].enabled == true && isJobCompleteOrActive[i] == false)
                {
                    activeJobCameras.Add(jobCameras[i]);

                    isJobCompleteOrActive[i] = true;
                }
            }
        }
    }

    void AssignCamsAtStart()
    {
        for (int i = 0; i < 5; i++)
        {
            jobCameras[i].rect = new Rect(jobCamLayoutPositions[i].x, jobCamLayoutPositions[i].y, jobCamLayoutPositions[i].z, jobCamLayoutPositions[i].w);
            jobCameras[i].GetComponent<Job>().cameraIndex = i;
            isJobCompleteOrActive[i] = true;
        }
    }


    public void JobComplete(int jobIndex)
    {
        jobCameras[jobIndex].enabled = false;
        //jobCamAnimators[jobIndex].SetTrigger("JobComplete");
        isJobComplete[jobIndex] = true;
        completedJobs++;


        for (int i = 0; i < jobCameras.Count; i++)
        {
            if (jobCameras[i].name == jobCameras[jobIndex].name)
            {
                activeJobCameras.Remove(activeJobCameras[i]);
            }
        }
    }
}

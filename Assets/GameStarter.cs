using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public Cinemachine.CinemachineBrain brain;
    public GameObject cam;
    public void StartGame()
    {
        defblend = brain.m_DefaultBlend;
        brain.m_DefaultBlend = new Cinemachine.CinemachineBlendDefinition(Cinemachine.CinemachineBlendDefinition.Style.Cut, 0f);
        brain.m_CameraCutEvent.AddListener(OnCut);
        cam.gameObject.SetActive(false);
    }
    public static Cinemachine.CinemachineBlendDefinition defblend;
    public static void OnCut(Cinemachine.CinemachineBrain brain)
    {
        brain.m_DefaultBlend = defblend;
    }
}

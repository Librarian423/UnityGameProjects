using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSetup : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return null;

        //if (photonView.IsMine)
        //{
           
        //}
        var brain = Camera.main.GetComponent<CinemachineBrain>();
        var vcam = brain.ActiveVirtualCamera as CinemachineVirtualCamera;
        vcam.Follow = transform;
        vcam.LookAt = transform;
    }
}

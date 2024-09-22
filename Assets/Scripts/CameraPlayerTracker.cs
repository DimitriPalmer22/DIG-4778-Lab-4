using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraPlayerTracker : MonoBehaviour
{
    // Cinemachine Virtual Camera
    private CinemachineVirtualCamera _vcam;

    private void Awake()
    {
        // Get the Cinemachine Virtual Camera component
        _vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set the target of the camera to the player
        _vcam.Follow = GameManager.Instance.Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

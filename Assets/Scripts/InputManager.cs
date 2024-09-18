using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private PlayerControls _playerControls;

    public PlayerControls PlayerControls => _playerControls;

    private void Awake()
    {
        // Set the instance to this
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // Create a new instance of PlayerControls
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        // Enable the PlayerControls
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        // Disable the PlayerControls
        _playerControls.Disable();
    }
}
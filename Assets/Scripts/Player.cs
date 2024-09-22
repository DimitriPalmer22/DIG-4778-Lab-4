using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject laserPrefab;
    private AudioSource audioSource;
    public AudioClip gun;

    private float speed = 6f;
    private float horizontalScreenLimit = 10f;
    private float verticalScreenLimit = 6f;
    private bool canShoot = true;

    private Vector2 moveVector;

    private bool _isShooting;

    // Start is called before the first frame update
    void Start()
    {
        //play sound
        audioSource = GetComponent<AudioSource>();

        // Subscribe to the Input System
        InputManager.Instance.PlayerControls.Gameplay.Move.performed += OnMovePerformed;
        InputManager.Instance.PlayerControls.Gameplay.Move.canceled += OnMoveCanceled;

        InputManager.Instance.PlayerControls.Gameplay.Shoot.performed += OnShootPerformed;
        InputManager.Instance.PlayerControls.Gameplay.Shoot.canceled += OnShootCanceled;
    }


    private void OnShootPerformed(InputAction.CallbackContext obj)
    {
        // Set the shooting flag to true
        _isShooting = true;
    }

    private void OnShootCanceled(InputAction.CallbackContext obj)
    {
        // Set the shooting flag to false
        _isShooting = false;
    }

    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        moveVector = obj.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {
        moveVector = Vector2.zero;
    }


    // Update is called once per frame
    void Update()
    {
        Movement();
        
        if (_isShooting)
            Shooting();
    }

    void Movement()
    {
        // Move the player
        transform.Translate(moveVector * (Time.deltaTime * speed));

        // Clamp the player within the screen
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -horizontalScreenLimit, horizontalScreenLimit),
            Mathf.Clamp(transform.position.y, -verticalScreenLimit, verticalScreenLimit),
            0
        );
    }


    void Shooting()
    {
        // Return if the player can't shoot
        if (!canShoot)
            return;

        Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        audioSource.Play();
        canShoot = false;
        StartCoroutine("Cooldown");
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}
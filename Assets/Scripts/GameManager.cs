using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public GameObject playerPrefab;
    public GameObject meteorPrefab;
    public GameObject bigMeteorPrefab;
    public bool gameOver = false;

    public int meteorCount = 0;
    
    public Player Player { get; private set; }

    private void Awake()
    {
        // Set the instance to this 
        Instance = this;
        
        // Create the player prefab
        Player = Instantiate(playerPrefab, transform.position, Quaternion.identity).GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMeteor", 1f, 2f);
        
        // Restart
        InputManager.Instance.PlayerControls.Gameplay.Restart.performed += Restart;
    }

    private void Restart(InputAction.CallbackContext obj)
    {
        if (!gameOver)
            return;
        
        SceneManager.LoadScene("Week5Lab");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
            CancelInvoke();

        if (meteorCount == 5)
            BigMeteor();
    }

    void SpawnMeteor()
    {
        Instantiate(meteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }

    void BigMeteor()
    {
        meteorCount = 0;
        Instantiate(bigMeteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }
}

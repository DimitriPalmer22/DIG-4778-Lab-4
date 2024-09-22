using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake()
    {
        // Get the text component
        _text = GetComponent<TMP_Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        // Update the text component
        _text.text = $"Score: {GameManager.Instance.Score}";
    }
}

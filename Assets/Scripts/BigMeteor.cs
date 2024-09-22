using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BigMeteor : MonoBehaviour, IScored
{
    [SerializeField] GameObject bigExplosionParticles;
    [SerializeField] CinemachineImpulseSource impulseSource;
    private int hitCount = 0;

    [SerializeField] private int score;

    public int Score => score;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 0.5f);

        if (transform.position.y < -11f)
        {
            Destroy(this.gameObject);
        }

        if (hitCount >= 5)
        {
            Instantiate(bigExplosionParticles, transform.position, transform.rotation).GetComponent<ParticleSystem>().Play();
            impulseSource.GenerateImpulse();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            Destroy(whatIHit.gameObject);
        }
        else if (whatIHit.tag == "Laser")
        {
            hitCount++;
            Destroy(whatIHit.gameObject);
        }
    }

    private void OnDestroy()
    {
        // Add the score to the GameManager
        GameManager.Instance.AddScore(Score);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private GameManager gameManager;
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            
            other.transform.position = new Vector3(0, 18, 0.25f);
            playerRb.useGravity = false;
            playerRb.velocity = new Vector3(0, 0, 0);

            gameManager.UpdateScore(points);
            gameManager.BallLost();
            gameManager.isBallDropped = false;
        }
    }
}

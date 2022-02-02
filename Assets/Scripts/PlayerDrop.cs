using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrop : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject player;
    public bool isMouseOver = false;
    private Vector3 mousePos;
    private Vector3 mouseOffset = new Vector3(0.25f, 0.25f, -17.5f);

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isMouseOver && !gameManager.isBallDropped && gameManager.isGameRunning)
        {
            player.transform.position = mousePos;
        }
    }

    private void OnMouseOver()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + mouseOffset;
    }

    private void OnMouseEnter()
    {
        isMouseOver = true;
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
    }

    private void OnMouseDown()
    {
        if (isMouseOver)
        {
            gameManager.isBallDropped = true;
            player.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}

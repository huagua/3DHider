using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
	private GameManager gameManager;
	private float speed;

	private void Awake()
	{
		GameObject managerObject = GameObject.FindWithTag("GameController");
		gameManager = managerObject.GetComponent<GameManager>();
		speed = gameManager.WhichSpeed(gameObject.tag);
	}

    void FixedUpdate()
    {
    	// if(!gameManager.gameOver)
    	transform.Translate(0, 0, speed*Time.deltaTime);
    }

    public void StartPlayer()
    {
    	speed = gameManager.WhichSpeed(gameObject.tag);
    }

    public void StopPlayer()
    {
    	speed = 0f;
    }
}
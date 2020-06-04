using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 游戏移动脚本，不同的物体有不同的速度
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

	// 以下两个函数用来控制物体的停止和行走
    public void StartPlayer()
    {
    	speed = gameManager.WhichSpeed(gameObject.tag);
    }

    public void StopPlayer()
    {
    	speed = 0f;
    }
}
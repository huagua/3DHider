using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject virus;
    public GameObject firePos;
    public GameObject normalPeople;
    public GameManager gameManager;

    private float fireRate = 3f;
    private float nextFire;

    private float speed = 2.5f;
    private int health;
    private int cure = 1;
    private int healPoint = 3;

    private void Awake()
    {
    	gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    void Update()
    {
    	if(!gameManager.gameOver && Time.time > nextFire)
    	{
    		nextFire = Time.time + fireRate;
    		Fire();
    	}

    	LeftAndRight();
    }

    private void Fire()
    {
    	Instantiate(virus, firePos.transform.position, Quaternion.identity);
    }

    private void LeftAndRight()
    {
    	if(transform.position.x <= -2.5)
    	{
    		speed = 2.5f;
    	}else if(transform.position.x >= 2.5)
    	{
    		speed = -2.5f;
    	}

    	transform.Translate(speed*Time.deltaTime, 0, 0);
    }

    // 该类感染者被治愈函数
    public void CureOnce()
    {
    	health += cure;
    	if(health >= healPoint)
    	{
    		gameManager.IncurOne(transform.position);
    		gameManager.InfectedIncur();
    		Destroy(gameObject);
    	}
    }
}

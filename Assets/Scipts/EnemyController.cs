using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 严重感染者控制脚本
public class EnemyController : MonoBehaviour
{
    public GameObject virus;
    public GameObject firePos;
    public GameObject normalPeople;
    public GameManager gameManager;

    // 控制感染者产生病毒的速度
    private float fireRate = 3f;
    private float nextFire;

    private float speed = 2.5f;

    // 治愈相关
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

    // 产生病毒
    private void Fire()
    {
    	Instantiate(virus, firePos.transform.position, Quaternion.identity);
    }

    // 控制感染者左右移动
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

    // 治疗该类感染者的方法
    public void CureOnce()
    {
        // 每次治愈health增加cure，等到health增加到healPoint阈值时，该感染者就会被治愈
    	health += cure;
    	if(health >= healPoint)
    	{
    		gameManager.IncurOne(transform.position);
    		gameManager.InfectedIncur();
    		Destroy(gameObject);
    	}
    }
}

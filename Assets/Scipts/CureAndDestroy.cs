using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 口罩绑定脚本，用来检测碰撞消灭病毒并治愈感染者
public class CureAndDestroy : MonoBehaviour
{
	private GameManager gameManager;
	public GameObject normalPeople;

	// 三个分数，对应不同的场景，销毁病毒时得分为：score、销毁普通感染者得分为：varScore、治疗一次严重感染者得分：infectScore
	private int score = 10;
    private int varScore = 20;
    private int infectScore = 30;

	private void Awake()
	{
		GameObject managerObject = GameObject.FindWithTag("GameController");
		gameManager = managerObject.GetComponent<GameManager>();
	}

	// 当口罩与其他碰撞体碰撞时（enter，刚刚进入时）调用
    private void OnTriggerEnter(Collider other)
    {
		// 如果其他碰撞体是病毒，就销毁两者，玩家加分
    	if(other.gameObject.tag == "Virus")
    	{
    		Destroy(this.gameObject);
    		Destroy(other.gameObject);

    		gameManager.AddScore(score);
    	}

		// 如果其他碰撞体是普通感染者（由正常行人感染病毒产生的），就销毁两者，并实例化出正常行人————成功治愈，玩家加分
    	if(other.gameObject.tag == "VarientPeople")
    	{
    		Destroy(this.gameObject);
            Destroy(other.gameObject);

    		Instantiate(normalPeople, other.transform.position, Quaternion.identity);

			gameManager.AddScore(varScore);
    	}

		// 如果其他碰撞体是严重感染者（始终存在的感染者），就销毁口罩，标记严重感染者（三次即可治愈严重感染者），玩家加分
    	if(other.gameObject.tag == "Infected")
    	{
    		other.gameObject.GetComponent<EnemyController>().CureOnce();
            gameManager.AddScore(infectScore);
    		Destroy(this.gameObject);
    	}

		// 如果其他碰撞体是正常行人，就销毁口罩，玩家不加分，浪费一个口罩
        if(other.gameObject.tag == "NormalPeople")
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 病毒、普通感染者，严重感染者绑定脚本
public class DestroyByContact : MonoBehaviour
{
	private GameManager gameManager;
	public GameObject varientPeople;

	private void Awake()
	{
		GameObject managerObject = GameObject.FindWithTag("GameController");
		gameManager = managerObject.GetComponent<GameManager>();
	}

    // 与其他碰撞体碰撞时调用
    void OnTriggerEnter(Collider other)
    {
		// 如果接触到玩家，玩家被感染，游戏结束
    	if(other.gameObject.tag == "Player")
    		gameManager.GameOver();

		// 如果接触到正常行人，正常行人被感染，实例化出普通感染者，并销毁正常行人
    	if(other.gameObject.tag == "NormalPeople")
    	{
    		Instantiate(varientPeople, other.transform.position, Quaternion.identity);
    		Destroy(other.gameObject);

			// 如果当前绑定的是病毒，销毁病毒
    		if(gameObject.tag == "Virus")
                Destroy(gameObject);
    	}
    }
}

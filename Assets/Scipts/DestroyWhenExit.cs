using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 地板绑定脚本
public class DestroyWhenExit : MonoBehaviour
{
	public GameManager gameManager;

	private void Awake()
	{
		gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
	}

	// 设置三个floor，当玩家离开一个floor后，就让该floor移动到前面，当做远处的floor，如此循环
    private void OnTriggerExit(Collider other)
    {
    	if(other.gameObject.tag == "Player")
    	{
    		// gameManager.FloorIncur(this.transform.position);
    		// Destroy(this.gameObject);
            Vector3 pos = transform.position;
            pos.z = transform.position.z + 300f;
            transform.position = pos;
    	}
    }
}

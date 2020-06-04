using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 静止的口罩绑定脚本
public class StaticMask : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {
    	player = GameObject.FindWithTag("Player");
    }

    // 当玩家获取到该口罩时，就增加玩家拥有的口罩数量
    private void OnTriggerEnter(Collider other)
    {
    	if(other.gameObject.tag == "Player")
    	{
    		Destroy(this.gameObject);
            
    		player.GetComponent<PlayerController>().AddMask();
    	}
    }

    // 销毁时绑定该函数
    private void OnDestroy()
    {
        if(player != null)
            player.GetComponent<PlayerController>().numOfStaticMask--;
    }
}

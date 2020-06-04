using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 超出范围，自我销毁
public class DestroySelf : MonoBehaviour
{
	public GameObject player;
    public GameManager gameManager;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(player != null)
    	{
            // 如果该物体的位置在玩家后面10米外，或者该物体的位置在玩家前面100米外，就自我销毁
    		if(transform.position.z + 10 < player.transform.position.z || transform.position.z > player.transform.position.z + 100)
	        {
	        	Destroy(this.gameObject);

                // 如果当前的物体是严重感染者，就调用gamemanager中的方法，产生一个新的严重感染者
                if(this.gameObject.tag == "Infected")
                {
                    gameManager.InfectedIncur();
                }
	        }
    	}
        
    }
}

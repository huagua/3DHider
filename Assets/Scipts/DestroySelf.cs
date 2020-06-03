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
    		if(transform.position.z + 10 < player.transform.position.z)
	        {
	        	Destroy(this.gameObject);
                if(this.gameObject.tag == "Infected")
                {
                    gameManager.InfectedIncur();
                }
	        }
    	}
        
    }
}

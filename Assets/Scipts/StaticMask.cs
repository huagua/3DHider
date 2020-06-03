using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMask : MonoBehaviour
{
    // public GameManager gameManager;
    public GameObject player;

    private void Awake()
    {
    	player = GameObject.FindWithTag("Player");
    	// gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
    	if(other.gameObject.tag == "Player")
    	{
    		Destroy(this.gameObject);
            
    		player.GetComponent<PlayerController>().AddMask();
    	}
    }

    private void OnDestroy()
    {
        if(player != null)
            player.GetComponent<PlayerController>().numOfStaticMask--;
    }
}

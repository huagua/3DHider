using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 携带病毒者触碰到player时，游戏结束
public class DestroyByContact : MonoBehaviour
{
	private GameManager gameManager;
	public GameObject varientPeople;

	private void Awake()
	{
		GameObject managerObject = GameObject.FindWithTag("GameController");
		gameManager = managerObject.GetComponent<GameManager>();
	}

    // void OnCollisionEnter(Collision other)
    void OnTriggerEnter(Collider other)
    {
    	if(other.gameObject.tag == "Player")
    		gameManager.GameOver();

    	if(other.gameObject.tag == "NormalPeople")
    	{
    		Instantiate(varientPeople, other.transform.position, Quaternion.identity);
    		Destroy(other.gameObject);
    		if(gameObject.tag != "Infected")
                Destroy(gameObject);
    	}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureAndDestroy : MonoBehaviour
{
	private GameManager gameManager;
	public GameObject normalPeople;
	private int score = 10;
    private int varScore = 20;
    private int infectScore = 30;

	private void Awake()
	{
		GameObject managerObject = GameObject.FindWithTag("GameController");
		gameManager = managerObject.GetComponent<GameManager>();
	}

    // void OnCollisionEnter(Collision other)
    private void OnTriggerEnter(Collider other)
    {
    	if(other.gameObject.tag == "Virus")
    	{
    		Destroy(this.gameObject);
    		Destroy(other.gameObject);

    		gameManager.AddScore(score);
    	}

    	if(other.gameObject.tag == "VarientPeople")
    	{
    		Destroy(this.gameObject);
            Destroy(other.gameObject);

            gameManager.AddScore(varScore);

    		Instantiate(normalPeople, other.transform.position, Quaternion.identity);
    	}

    	if(other.gameObject.tag == "Infected")
    	{
    		other.gameObject.GetComponent<EnemyController>().CureOnce();
            gameManager.AddScore(infectScore);
    		Destroy(this.gameObject);
    	}

        if(other.gameObject.tag == "NormalPeople")
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenExit : MonoBehaviour
{
	public GameManager gameManager;

	private void Awake()
	{
		gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
	}

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

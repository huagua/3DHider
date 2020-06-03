using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonotGetCloser : MonoBehaviour
{
	// public GameObject player;

	// private void Awake()
	// {
	// 	// player = GameObject.FindWithTag("Player");
	// }

    void OnTriggerEnter(Collider other)
    {
    	print("hhhhhh");
    	if(other.gameObject.tag == "NormalPeople")
    	{
    		print("eeeeee");
    		other.gameObject.GetComponent<MoveForward>().StopPlayer();
    		GetComponent<MoveForward>().StopPlayer();
    	}
    }

    void OnTriggerExit(Collider other)
    {
    	if(other.gameObject.tag == "NormalPeople")
    	{
    		other.gameObject.GetComponent<MoveForward>().StartPlayer();
    		GetComponent<MoveForward>().StartPlayer();
    	}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player绑定脚本，用来控制使普通行人和玩家的身体不能相互穿过
public class DonotGetCloser : MonoBehaviour
{
	// 进入碰撞体时，玩家和普通行人速度变为0
    void OnTriggerEnter(Collider other)
    {
    	if(other.gameObject.tag == "NormalPeople")
    	{
    		other.gameObject.GetComponent<MoveForward>().StopPlayer();
    		GetComponent<MoveForward>().StopPlayer();
    	}
    }

	// 离开碰撞体时，恢复玩家和普通行人的速度
    void OnTriggerExit(Collider other)
    {
    	if(other.gameObject.tag == "NormalPeople")
    	{
    		other.gameObject.GetComponent<MoveForward>().StartPlayer();
    		GetComponent<MoveForward>().StartPlayer();
    	}
    }
}

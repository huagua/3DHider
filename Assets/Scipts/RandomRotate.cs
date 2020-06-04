using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 静止的口罩绑定脚本，任意旋转
public class RandomRotate : MonoBehaviour
{
    public float tumble = 5f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject mask;
    public GameObject firePos;
    public GameManager gameManager;

 	private float fireRate = 0.5f;
 	private float nextFire;

    private Vector2 touchPos;
    private Vector2 finPos;
    private float maxSqrDistance = 0.1f;

    private int numOfMask = 10;
    public int numOfStaticMask = 0;
    private float time = 0.5f;
    public Text maskText;


    private void Awake()
    {
    	gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(!gameManager.gameOver)
    	{
    		FireMask();

	    	if(numOfMask < 10 && numOfStaticMask < 1)
	    	{
	    		gameManager.StaticMaskIncur();
	    		numOfStaticMask++;
	    	}
    	}
    }

    // 玩家产生口罩
    private void FireMask()
    {
    	if(Input.GetButton("Fire1") && Time.time > nextFire && numOfMask > 0)
    	{
    		nextFire = Time.time + fireRate;
    		Instantiate(mask, firePos.transform.position, Quaternion.identity);
            numOfMask--;
            maskText.text = numOfMask.ToString();
    	}
    }

    // 以下两个函数用于控制玩家的左右移动
    private void OnMouseDown()
    {
        touchPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        finPos = Input.mousePosition;

        Vector2 dir = finPos - touchPos;
            if((dir).sqrMagnitude > maxSqrDistance)
            {
                Vector3 pos = transform.position;
                if(dir.x < 0)
                {
                    // 向左
                	StartCoroutine(LerpOfPlayer(pos, -1));
                }
                else if(dir.x > 0)
                {
                    // 向右
                    StartCoroutine(LerpOfPlayer(pos, 1));
                }
            }
    }

    // 此方法用于控制玩家顺滑移动
    private IEnumerator LerpOfPlayer(Vector3 startPos, int flag)
    {
    	Vector3 endPos = new Vector3(
        	Mathf.Clamp(startPos.x + flag*2.5f, -2.5f, 2.5f),
        	startPos.y,
        	startPos.z
        	);

    	for(float t = 0; t < time; t += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, t/time);
            yield return 0;
        }

        transform.position = endPos;
    }

    // 玩家获取口罩的方法
    public void AddMask()
    {
        numOfMask += 10;
        maskText.text = numOfMask.ToString();
    }
}

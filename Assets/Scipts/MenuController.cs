using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// menu场景中的控制脚本
public class MenuController : MonoBehaviour
{
	public Text maxScoreText;
	private int maxScore;

	private void Awake()
	{
		// 获取到历史最高分
		maxScore = PlayerPrefs.GetInt("maxScore");
		maxScoreText.text = "历史最高分：" + maxScore;
	}

	// button触发函数
    public void OnStartGame()
    {
    	SceneManager.LoadScene(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
	public Text maxScoreText;
	private int maxScore;

	private void Awake()
	{
		maxScore = PlayerPrefs.GetInt("maxScore");
		// maxScoreText.text = maxScore.ToString();
		maxScoreText.text = "历史最高分：" + maxScore;
	}

    public void OnStartGame()
    {
    	SceneManager.LoadScene(1);
    }
}

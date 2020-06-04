using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 各种速度
	private float playerSpeed = 5;
    private float virusSpeed = -10;
    private float maskSpeed = 10;
    private float normalPeopleSpeed = -2;
    private float varientPeopleSpeed = -7;
    private float infectedSpeed = -3;
    private float normalSpeed = 2;
	private float increasingSpeed = 5;


	private static int score = 0;
    public GameObject player;
    public GameObject infected;
    public GameObject staticMask;

    private float[] xposOfNormal = {-2.5f, 0f, 2.5f};
    public GameObject[] normalPeoples;
    private float normalWait = 2f;

    // 各种UI组件，在unity面板中赋值
    public GameObject pausePanel;
    public GameObject newRecordPanel;
    public GameObject gameOverPanel;
    public GameObject onGamePanel;

    public Text socreText;
    public Text newRecordScore;
    public Text finalScore;

    // 游戏结束flag
    public bool gameOver;

    // 以下四个函数均是button触发函数
    public void OnPauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void OnContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void OnRestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

	private void Awake()
	{
		Time.timeScale = 1;

        newRecordPanel.SetActive(false);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        onGamePanel.SetActive(true);
	}

    void Start()
    {
        StartCoroutine(NormalPeopleIncur());
    }

    // 玩家加分
    public void AddScore(int value)
    {
    	score += value;

        socreText.text = score.ToString();

    	// 玩家分数越高，速度越快
    	if(score % 200 == 0)  playerSpeed += increasingSpeed;
    }

    // 游戏结束方法
    public void GameOver()
    {
    	// Time.timeScale = 0;
        gameOver = true;
        onGamePanel.SetActive(false);
        SaveData();
    }

    // 游戏结束时需要保存数据，仅仅保存历史最高分即可
    private void SaveData()
    {
        int maxValue = PlayerPrefs.GetInt("maxScore");
        if(score > maxValue)
        {
            PlayerPrefs.SetInt("maxScore", score);
            newRecordPanel.SetActive(true);
            newRecordScore.text = score.ToString();
        }else
        {
            NextPeriodGameOver();
        }
    }

    // 显示游戏结束面板
    public void NextPeriodGameOver()
    {
        newRecordPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        finalScore.text = score.ToString();
    }

    // 随机出现口罩
    public void StaticMaskIncur()
    {
        Vector3 pos = new Vector3(
            xposOfNormal[Random.Range(0, xposOfNormal.Length)],
            0,
            Random.Range(player.transform.position.z+50f, player.transform.position.z+100f)
        );

        Instantiate(staticMask, pos, Quaternion.identity);
    }

    // 随机出现普通行人
    private IEnumerator NormalPeopleIncur()
    {
        while(true)
        {
            Vector3 playerPos = player.transform.position;
            Vector3 pos = new Vector3(
                xposOfNormal[Random.Range(0, xposOfNormal.Length)],
                -2,
                Random.Range(playerPos.z + 50f, playerPos.z + 100f)
                );
            IncurOne(pos);
            // Instantiate(normalPeoples[Random.Range(0, normalPeoples.Length)], pos, Quaternion.identity);
            
            yield return new WaitForSeconds(normalWait);
        }
    }

    // 出现一个普通行人
    public void IncurOne(Vector3 pos)
    {
        Instantiate(normalPeoples[Random.Range(0, normalPeoples.Length)], pos, Quaternion.identity);
    }

    // 固定位置出现infected
    public void InfectedIncur()
    {
        if(player != null)
        {
            Vector3 pos = player.transform.position;
            pos.y = -2f;
            pos.z += 100f;

            Instantiate(infected, pos, Quaternion.identity);
        }
    }

    // 判断使用哪个速度
    public float WhichSpeed(string tag)
    {
        switch(tag)
        {
            case "Player":  return playerSpeed;
            case "Virus": return virusSpeed;
            case "Mask": return maskSpeed;
            case "NormalPeople": return normalPeopleSpeed;
            case "VarientPeople": return varientPeopleSpeed;
            case "Infected": return infectedSpeed;
            default: return normalSpeed;
        }
    }
}

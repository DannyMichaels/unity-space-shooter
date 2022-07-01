using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  public int currentLives = 3;// how many lives player has in each levels
  public float respawnTime = 2f;
  public int currentScore;
  private int highScore = 500;

  private void Awake()
  {
    instance = this;
  }

  // Start is called before the first frame update
  void Start()
  {
    UIManager.instance.UpdateCurrentLivesText();
    UIManager.instance.UpdateCurrentScoreText();

    InitHighScore();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void HandlePlayerDeath()
  {
    WaveManager.instance.canSpawnWaves = false; // stop spawning waves

    currentLives--;
    UIManager.instance.UpdateCurrentLivesText();

    if (currentLives > 0)
    {
      // respawn
      StartCoroutine(RespawnCo());
    }
    else
    {
      // game over
      StartGameOver();
    }
  }

  public IEnumerator RespawnCo()
  {
    yield return new WaitForSeconds(respawnTime);
    PlayerHealthController.instance.RespawnPlayer();
    WaveManager.instance.ContinueSpawning(); // can spawn waves again
  }

  public void StartGameOver()
  {
    UIManager.instance.gameOverScreen.SetActive(true);
    WaveManager.instance.canSpawnWaves = false;
    MusicController.instance.PlayGameOverMusic();
  }

  public void AddScore(int scoreToAdd)
  {
    currentScore += scoreToAdd;
    UIManager.instance.UpdateCurrentScoreText();

    if (currentScore > highScore)
    {
      highScore = currentScore;
      UIManager.instance.highScoreText.text = $"Hi-Score: {highScore}";
      PlayerPrefs.SetInt("HighScore", highScore);
    }
  }

  private void InitHighScore()
  {
    highScore = PlayerPrefs.GetInt("HighScore");
    UIManager.instance.highScoreText.text = $"Hi-Score: {highScore}";
  }

  public IEnumerator EndLevelCo()
  {
    UIManager.instance.levelEndScreen.SetActive(true);
    yield return new WaitForSeconds(.5f);
  }
}

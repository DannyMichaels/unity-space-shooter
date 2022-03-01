using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  public int currentLives = 3;// how many lives player has in each levels
  public float respawnTime = 2f;
  public int currentScore;

  private void Awake()
  {
    instance = this;
  }

  // Start is called before the first frame update
  void Start()
  {
    UIManager.instance.UpdateCurrentLivesText();
    UIManager.instance.UpdateCurrentScoreText();
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
  }

  public void AddScore(int scoreToAdd)
  {
    currentScore += scoreToAdd;
    UIManager.instance.UpdateCurrentScoreText();
  }
}

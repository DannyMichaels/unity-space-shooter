using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
  public static UIManager instance;

  public GameObject gameOverScreen;
  public Text currentLivesText, scoreText;

  public Slider healthBar;

  private void Awake()
  {
    instance = this;
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void Restart()
  {
    string activeSceneName = SceneManager.GetActiveScene().name;

    SceneManager.LoadScene(activeSceneName);
  }

  public void GoToMainMenu()
  {

  }

  public void UpdateCurrentLivesText()
  {
    int newLivesValue = GameManager.instance.currentLives;
    currentLivesText.text = $"x {newLivesValue}";
  }

  public void UpdateCurrentScoreText()
  {
    int newScoreValue = GameManager.instance.currentScore;
    scoreText.text = $"Score: {newScoreValue}";
  }
}

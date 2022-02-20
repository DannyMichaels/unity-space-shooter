using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
  public static UIManager instance;

  public GameObject gameOverScreen;

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
}

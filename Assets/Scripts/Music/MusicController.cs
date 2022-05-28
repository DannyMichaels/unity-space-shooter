using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
  public static MusicController instance;

  public AudioSource levelMusic, bossMusic, victoryMusic, gameOverMusic;

  private void Awake()
  {
    instance = this;
  }

  // Start is called before the first frame update
  void Start()
  {
    levelMusic.Play();
  }

  // Update is called once per frame
  void Update()
  {

  }

  void StopMusic()
  {
    levelMusic.Stop();
    bossMusic.Stop();
    victoryMusic.Stop();
    gameOverMusic.Stop();
  }

  public void PlayBossMusic()
  {
    StopMusic();
    bossMusic.Play();
  }

  public void PlayVictoryMusic()
  {
    StopMusic();
    victoryMusic.Play();
  }

  public void PlayGameOverMusic()
  {
    StopMusic();
    gameOverMusic.Play();
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
  public static WaveManager instance;

  public WaveObject[] waves;

  public int currentWaveIndex;
  public float timeToNextWave;

  public bool canSpawnWaves;

  private void Awake()
  {
    instance = this;
  }

  // Start is called before the first frame update
  void Start()
  {
    timeToNextWave = waves[0].timeToSpawn; // start the timer
  }

  // Update is called once per frame
  void Update()
  {
    HandleWavesSpawn();
  }

  private void HandleWavesSpawn()
  {
    if (!canSpawnWaves) return;

    timeToNextWave -= Time.deltaTime;

    // if done waiting for next wave. (if timer is 0)
    if (timeToNextWave <= 0)
    {
      // create the wave of currentWave index.
      Instantiate(waves[currentWaveIndex].theWave, transform.position, transform.rotation);

      if (currentWaveIndex < waves.Length - 1) // if didn't reach end of array 
      {
        // increment currentWaveIndex
        currentWaveIndex++;

        timeToNextWave = waves[currentWaveIndex].timeToSpawn; // restart the timer for next waves time to spawn
      }
      else
      {
        // if reached end of array.
        canSpawnWaves = false;
      }
    }
  }

  public void ContinueSpawning()
  {
    if (currentWaveIndex <= waves.Length - 1 && timeToNextWave > 0)
    {
      canSpawnWaves = true;
    }
  }
}

// can be viewable within unity but not make it have any functional code that runs by itself
[System.Serializable]
public class WaveObject
{
  public float timeToSpawn;
  public EnemyWave theWave;
}

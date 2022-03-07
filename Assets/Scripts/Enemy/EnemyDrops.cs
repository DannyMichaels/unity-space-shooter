using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
  public GameObject[] powerUps;
  public int dropSuccessRate = 15;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void DropRandomPowerup(Transform transform)
  {
    int randomChance = Random.Range(0, 100);
    if (randomChance > dropSuccessRate)
    {
      return;
    }

    Debug.Log("dropping random powerup");

    // in C# .Length will pick the last element starting from 0 (so indexed), unlike javascript where u need to do .length - 1
    int randomPick = Random.Range(0, powerUps.Length);
    Debug.Log("rand random powerup");

    Instantiate(powerUps[randomPick], transform.position, transform.rotation);
  }
}

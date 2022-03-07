using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
  public int currentHealth;
  public GameObject deathEffect;
  public int scoreValue = 100; // score to add when enemy is killed

  void Awake()
  {
  }
  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void DamageEnemy()
  {
    currentHealth--;
    if (currentHealth <= 0)
    {
      GameManager.instance.AddScore(scoreValue);

      GetComponent<EnemyDrops>().DropRandomPowerup(transform);
      DestroyEnemy();
    }
  }

  public void DestroyEnemy()
  {

    Destroy(gameObject);
    Instantiate(deathEffect, transform.position, transform.rotation);
  }
}

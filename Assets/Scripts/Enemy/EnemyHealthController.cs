using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
  public int currentHealth;
  public GameObject deathEffect;

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
      DestroyEnemy();
    }
  }

  public void DestroyEnemy()
  {
    Destroy(gameObject);
    Instantiate(deathEffect, transform.position, transform.rotation);
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
  public int currentHealth;
  public int maxHealth;




  [HideInInspector]
  public static PlayerHealthController instance; // instance = Singleton: create a version of this script that only one version of it can exist
  public GameObject deathEffect;

  void Awake()
  {
    instance = this;
  }

  // Start is called before the first frame update
  void Start()
  {
    currentHealth = maxHealth;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void DamagePlayer()
  {
    currentHealth -= 1;

    if (currentHealth <= 0)
    {
      KillPlayer();
    }
  }

  public void KillPlayer()
  {
    Instantiate(deathEffect, transform.position, transform.rotation);
    // Destroy(gameObject);
    gameObject.SetActive(false);
  }
}
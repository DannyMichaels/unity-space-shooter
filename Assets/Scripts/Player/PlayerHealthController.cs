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

  public int shieldPower, shieldMaxPower = 2;
  public GameObject theShield;

  void Awake()
  {
    instance = this;
  }

  // Start is called before the first frame update
  void Start()
  {
    UIManager.instance.healthBar.maxValue = maxHealth;
    SetCurrentHealth(maxHealth);

    UIManager.instance.shieldBar.maxValue = shieldMaxPower;
    UIManager.instance.shieldBar.value = shieldPower;

    ActivateShield();
  }

  // Update is called once per frame
  void Update()
  {
  }

  public void DamagePlayer()
  {
    if (!PlayerInvincibility.instance.CanTakeDamage()) return;

    if (theShield.activeInHierarchy)
    {
      shieldPower--;
      if (shieldPower <= 0)
      {
        theShield.SetActive(false);
      }

      UIManager.instance.shieldBar.value = shieldPower;
      return;
    }

    SetCurrentHealth(currentHealth - 1);

    if (currentHealth <= 0)
    {
      KillPlayer();
    }
  }

  public void KillPlayer()
  {
    Instantiate(deathEffect, transform.position, transform.rotation);
    gameObject.SetActive(false);

    GameManager.instance.HandlePlayerDeath();
  }

  public void RespawnPlayer()
  {
    gameObject.SetActive(true);
    SetCurrentHealth(maxHealth);

    PlayerInvincibility.instance.MakeInvincibile();
  }

  private void SetCurrentHealth(int value)
  {
    currentHealth = value;
    UIManager.instance.healthBar.value = currentHealth;
  }

  public void ActivateShield()
  {
    theShield.SetActive(true);
    shieldPower = shieldMaxPower;

    UIManager.instance.shieldBar.value = shieldPower;
  }
}

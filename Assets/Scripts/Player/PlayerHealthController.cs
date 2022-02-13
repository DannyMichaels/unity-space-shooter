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

  public float invincibilityDuration = 2f;
  private float invincibleCounter;
  public SpriteRenderer theSR;

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
    UseInvincibility();
  }

  public void DamagePlayer()
  {
    bool canTakeDamage = invincibleCounter <= 0;
    if (!canTakeDamage) return;

    currentHealth -= 1;

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
    currentHealth = maxHealth;

    MakePlayerInvincible();
  }

  private void MakePlayerInvincible()
  {
    invincibleCounter = invincibilityDuration;
    ChangePlayerTransparency(.5f);
  }

  private void ChangePlayerTransparency(float alpha)
  {
    theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, alpha); // change transparency so player knows he's invincible or not
  }

  private void UseInvincibility()
  {
    if (invincibleCounter >= 0)
    {
      invincibleCounter -= Time.deltaTime;
      if (invincibleCounter <= 0)
      {
        ChangePlayerTransparency(1f); // reset to 1.
      }
    }
  }
}

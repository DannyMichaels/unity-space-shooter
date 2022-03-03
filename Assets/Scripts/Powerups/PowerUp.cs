using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
  public bool isShield;
  public bool isSpeedBoost;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      Destroy(gameObject); // it was picked up!

      if (isShield)
      {
        PlayerShield.instance.ActivateShield();
      }

      if (isSpeedBoost)
      {
        PlayerSpeedBoost.instance.ActivateSpeedBoost();
      }
    }
  }
}

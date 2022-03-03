using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedBoost : MonoBehaviour
{
  public static PlayerSpeedBoost instance;
  private float normalSpeed;
  public float boostSpeed; // speed when speedboosted (picked up speed boost powerup)
  public float boostLength; // how long is the boost?
  private float boostCounter;

  void Awake()
  {
    instance = this;
  }
  // Start is called before the first frame update
  void Start()
  {
    normalSpeed = PlayerController.instance.moveSpeed;
  }

  // Update is called once per frame
  void Update()
  {
    // boost duration started
    if (boostCounter > 0)
    {
      boostCounter -= Time.deltaTime;

      if (boostCounter <= 0)
      {
        // boost duration ended
        DeActivateSpeedBoost();
      }
    }
  }

  public void ActivateSpeedBoost()
  {
    boostCounter = boostLength;
    PlayerController.instance.moveSpeed = boostSpeed;
  }

  public void DeActivateSpeedBoost()
  {
    PlayerController.instance.moveSpeed = normalSpeed;

  }
}

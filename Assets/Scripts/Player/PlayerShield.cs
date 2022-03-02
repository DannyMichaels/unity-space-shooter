using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
  public static PlayerShield instance;
  public int shieldPower, shieldMaxPower = 2;
  public GameObject theShield;


  void Awake()
  {
    instance = this;
  }
  // Start is called before the first frame update
  void Start()
  {
    UIManager.instance.shieldBar.maxValue = shieldMaxPower;
    UIManager.instance.shieldBar.value = shieldPower;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void ActivateShield()
  {
    theShield.SetActive(true);
    shieldPower = shieldMaxPower;

    UIManager.instance.shieldBar.value = shieldPower;
  }

  public bool IsActive()
  {
    return theShield.activeInHierarchy;
  }

  public void DamageShield()
  {
    shieldPower--;

    if (shieldPower <= 0)
    {
      theShield.SetActive(false);
    }

    UIManager.instance.shieldBar.value = shieldPower;
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player double shoot powerup! gets reverted when player dies
public class PlayerDoubleShot : MonoBehaviour
{
  public static PlayerDoubleShot instance;

  public bool doubleShotActive;
  public float doubleShotOffset;


  void Awake()
  {
    instance = this;
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void Activate()
  {
    doubleShotActive = true;
  }

  public void DeActivate()
  {
    doubleShotActive = false;
  }

  public void Fire(GameObject shot, Transform shotPoint)
  {
    Instantiate(shot, shotPoint.position + new Vector3(0f, PlayerDoubleShot.instance.doubleShotOffset, 0f), shotPoint.rotation);
    Instantiate(shot, shotPoint.position - new Vector3(0f, PlayerDoubleShot.instance.doubleShotOffset, 0f), shotPoint.rotation);
  }
}

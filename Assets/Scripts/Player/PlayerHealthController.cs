using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
  [HideInInspector]
  public static PlayerHealthController instance; // instance = Singleton: create a version of this script that only one version of it can exist
  public GameObject playerExplodeEffect;

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

  public void KillPlayer()
  {
    Instantiate(playerExplodeEffect, transform.position, transform.rotation);
    Destroy(gameObject);
  }
}

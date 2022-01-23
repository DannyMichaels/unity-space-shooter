using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
  public float shotSpeed = 7f;
  public GameObject impactEffect;

  private bool readyToRemove;

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
    transform.position += new Vector3(shotSpeed * Time.deltaTime, 0f, 0f);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    Instantiate(impactEffect, transform.position, transform.rotation);
    Destroy(gameObject);
  }

  void OnBecameVisible()
  {
    readyToRemove = true;
  }

  private void OnBecameInvisible()
  {
    // destroy bullet once it goes out of screen
    if (readyToRemove)
    {
      Destroy(gameObject);
    }
  }
}

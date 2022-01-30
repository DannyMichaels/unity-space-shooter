using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// hurts player on collision
public class HurtPlayer : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  // use OnCollisionEnter2D if you don't want to make the collider a trigger
  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      PlayerHealthController.instance.DamagePlayer();
    }
  }
}

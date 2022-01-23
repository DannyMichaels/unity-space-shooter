using UnityEngine;

public class InstakillPlayer : MonoBehaviour
{
  public GameObject playerExplodeEffect;

  // kills player instantly on collision
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      Instantiate(playerExplodeEffect, other.transform.position, other.transform.rotation);


      Destroy(other.gameObject);
    }
  }

}

using UnityEngine;

public class InstakillPlayer : MonoBehaviour
{

  void Awake()
  {

  }
  // kills player instantly on collision
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      PlayerHealthController.instance.KillPlayer();
      PlayerHealthController.instance.RespawnPlayer();
    }
  }
}

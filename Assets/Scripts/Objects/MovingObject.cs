using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
  public float moveSpeed;
  private bool readyToRemove;


  // Update is called once per frame
  void Update()
  {
    transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
  }

  void OnBecameVisible()
  {
    readyToRemove = true;
  }

  /// <summary>
  /// OnBecameInvisible is called when the renderer is no longer visible by any camera.
  /// </summary>
  private void OnBecameInvisible()
  {
    if (readyToRemove)
    {
      Destroy(gameObject);
    }
  }
}

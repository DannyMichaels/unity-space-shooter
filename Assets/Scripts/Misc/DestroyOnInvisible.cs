using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// destroys an object if it's off camera
public class DestroyOnInvisible : MonoBehaviour
{
  private bool readyToRemove;

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

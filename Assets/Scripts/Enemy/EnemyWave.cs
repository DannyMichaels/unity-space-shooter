using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    // all enemies that are a part of the wave are no longer a child of the object
    transform.DetachChildren();


    Destroy(gameObject); // can destroy the empty wave after the enemies have spawned and detached from this parent
  }

  // Update is called once per frame
  void Update()
  {

  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  public float moveSpeed;

  public Vector2 startDirection; // the initial direction enemy will be going

  public bool shouldChangeDirection; // will only change direction if this bool is set to true
  public float changeDirectionXPoint; // the point on the x axis where the enemy will start changing direction
  public Vector2 changedDirection; // direction to go once the direction has been changed

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    HandleEnemyMove();
  }


  private void HandleEnemyMove()
  {
    // transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

    if (!shouldChangeDirection)
    {


      transform.position += calcNewPosition(startDirection.x, startDirection.y);
    }
    else
    {
      if (transform.position.x > changeDirectionXPoint)
      {
        transform.position += calcNewPosition(startDirection.x, startDirection.y);
      }
      else
      {
        transform.position += calcNewPosition(changedDirection.x, changedDirection.y);
      }
    }
  }


  private Vector3 calcNewPosition(float x, float y)
  {
    float newXPos = x * moveSpeed * Time.deltaTime;
    float newYPos = y * moveSpeed * Time.deltaTime;

    return new Vector3(newXPos, newYPos, 0f);
  }
}

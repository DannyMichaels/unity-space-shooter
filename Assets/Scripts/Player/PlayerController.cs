using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  public float moveSpeed;
  public Rigidbody2D theRB;

  public Transform bottomLeftLimit, topRightLimit;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    HandlePlayerMove();
    KeepPlayerInBounds();
  }

  private void HandlePlayerMove()
  {
    theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
  }


  // @method KeepPlayerInBounds
  // @desc keep player in camera range (don't let him go outside). think of how in chicken invaders you can't go outside range.
  private void KeepPlayerInBounds()
  {
    float clampedX = Mathf.Clamp(transform.position.x, bottomLeftLimit.position.x, topRightLimit.position.x);
    float clampedY = Mathf.Clamp(transform.position.y, bottomLeftLimit.position.y, topRightLimit.position.y);

    transform.position = new Vector3(clampedX, clampedY, transform.position.z);
  }
}

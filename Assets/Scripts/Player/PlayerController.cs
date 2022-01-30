using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  public float moveSpeed;
  public Rigidbody2D theRB;

  public Transform bottomLeftLimit, topRightLimit;

  public Transform shotPoint; // position to fire shots from
  public GameObject shot; // object to be shot when player is shooting

  public float timeBetweenShots = .1f; // time to wait before each shot if Fire1 IS HELD DOWN.
  private float shotWaitCounter; // counter that will start after each shot.

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    HandlePlayerMove();
    KeepPlayerInBounds();
    HandleShoot();
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

  private void HandleShoot()
  {
    /*
      as soon as player presses fire1 and is holding it:
      shot counter will be equal to a certain amount and then we will start counting down
      and if it goes below or == 0 we will put a new bullet into the scene and start counting down again.
    */


    // pressed once
    if (Input.GetButtonDown("Fire1"))
    {
      Instantiate(shot, shotPoint.position, shotPoint.rotation);

      shotWaitCounter = timeBetweenShots; // start counter
    }


    // holding the button
    if (Input.GetButton("Fire1"))
    {
      // shotWaitCounter will keep going down until it's 0, if it's 0 we will create the new bullet
      shotWaitCounter -= Time.deltaTime;


      // if less than or equal to zero, it means we are done waiting
      if (shotWaitCounter <= 0)
      {
        // if it's less than or == 0, then that means we can create another shot
        Instantiate(shot, shotPoint.position, shotPoint.rotation);

        // it also means we need to restart our counter
        shotWaitCounter = timeBetweenShots;
      }
    }
  }
}

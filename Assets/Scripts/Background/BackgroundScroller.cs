using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
  public Transform BG1, BG2;
  public float scrollSpeed;

  private float bgWidth;

  // Start is called before the first frame update
  void Start()
  {
    bgWidth = BG1.GetComponent<SpriteRenderer>().sprite.bounds.size.x; // get how wide the image is
  }

  // Update is called once per frame
  void Update()
  {
    ScrollBackground();
  }


  // @method scrollBG
  // scroll by scroll speed every frame (moves to left in x axis so it looks like player is moving right)
  private void ScrollBackground()
  {
    // BG1.position = new Vector3(BG1.position.x - (scrollSpeed * Time.deltaTime), BG1.position.y, BG1.position.z);
    BG1.position -= new Vector3(scrollSpeed * Time.deltaTime, BG1.position.y, BG1.position.z); // this is the same code as above but written differently
    BG2.position -= new Vector3(scrollSpeed * Time.deltaTime, BG2.position.y, BG2.position.z);

    // if bg1 is moved so far that it's off the screen, move it to the right ("infinite scroll" feel), same with bg2
    HandleMoveToEnd(BG1);
    HandleMoveToEnd(BG2);
  }

  private void HandleMoveToEnd(Transform bg)
  {
    // if bg is moved so far that it's off the screen, move it to the right
    if (bg.position.x < -bgWidth - 1)
    {
      bg.position += new Vector3(bgWidth * 2f, bg.position.y, bg.position.z);
    }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvincibility : MonoBehaviour
{
  public static PlayerInvincibility instance; // instance = Singleton: create a version of this script that only one version of it can exist
  public float invincibilityDuration = 2f;
  [HideInInspector]
  public float invincibleCounter;
  public SpriteRenderer theSR;

  void Awake()
  {
    instance = this;
  }

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    if (invincibleCounter >= 0)
    {
      invincibleCounter -= Time.deltaTime;
      if (invincibleCounter <= 0)
      {
        ChangeSpriteTransparency(1f); // reset to 1.
      }
    }
  }

  public void MakeInvincibile()
  {
    invincibleCounter = invincibilityDuration;
    ChangeSpriteTransparency(.5f);
  }

  private void ChangeSpriteTransparency(float alpha)
  {
    theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, alpha); // change transparency so player knows he's invincible or not
  }

  public bool CanTakeDamage()
  {
    return invincibleCounter <= 0;
  }
}

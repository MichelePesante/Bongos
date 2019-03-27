using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BongoInput : MonoBehaviour
{
    private Collider2D myCollider2D;

    public void Setup()
    {
        myCollider2D = GetComponent<Collider2D>();
    }

    public bool CheckTouches()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                    if (myCollider2D.OverlapPoint(touchPos))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}

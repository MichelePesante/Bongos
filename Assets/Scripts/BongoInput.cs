using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BongoInput : MonoBehaviour
{
    private Collider2D collider2D;

    void Awake()
    {
        collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if(Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                    if (collider2D.OverlapPoint(touchPos))
                    {
                        print("Touch");
                    }
                }
            }
        }
    }
}

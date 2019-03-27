using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BongoData : MonoBehaviour
{
    [SerializeField]
    private Tier currentTier;
    private BongoView currentView;
    private SpriteRenderer spriteRenderer;

    public void Setup()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentView = ViewManager.Instance.GetView(currentTier);
        spriteRenderer.sprite = currentView.CurrentSprite;
        ChangeColor(false);
    }

    public void ChangeColor(bool isActive)
    {
        if (isActive)
        {
            spriteRenderer.color = currentView.ActiveColor;
        }
        else
        {
            spriteRenderer.color = currentView.UnactiveColor;
        }
    }
}
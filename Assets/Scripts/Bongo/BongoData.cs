using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BongoData : MonoBehaviour
{
    [SerializeField]
    private TierEnum currentTier;
    private BongoView currentView;
    private SpriteRenderer spriteRenderer;
    private int spawnPercentage;
    private int bongoMaxValue;

    public void Setup()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentView = ViewManager.Instance.GetView(currentTier);
        spriteRenderer.sprite = currentView.CurrentSprite;
        spawnPercentage = currentView.SpawnPercentage;
        bongoMaxValue = currentView.BongoMaxValue;
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

    public TierEnum GetCurrentTier()
    {
        return currentTier;
    }

    public int GetSpawnPercentage()
    {
        return spawnPercentage;
    }

    public int GetMaxValue()
    {
        return bongoMaxValue;
    }
}
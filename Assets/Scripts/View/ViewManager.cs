using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public static ViewManager Instance;

    [SerializeField]
    private List<BongoView> Views;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public BongoView GetView(TierEnum viewTier)
    {
        if (viewTier <= 0)
        {
            throw new System.Exception("Tier di qualche bongo non impostato!!!");
        }
        else
        {
            return Views[(int)viewTier - 1];
        }
    }
}

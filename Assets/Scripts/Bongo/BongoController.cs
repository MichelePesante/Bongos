using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BongoController : MonoBehaviour
{
    [Header("Behaviours")]
    [SerializeField]
    private BongoData bongoData;
    [SerializeField]
    private BongoInput bongoInput;

    [Header("Modifiers")]
    /// <summary>
    /// Tempo che ci impiega l'indicatore a raggiungere il centro del bongo
    /// </summary>
    [Tooltip("Tempo che ci impiega l'indicatore a raggiungere il centro del bongo")]
    [SerializeField]
    [Range (0, 10)]
    private float markerTime;
    private Timer timer;
    private int currentScoreValue;
    public bool IsActive { get; private set; }

    private void Update()
    {
        TickBongo();
    }

    #region Setup

    public void Setup()
    {
        timer = new Timer();
        bongoData.Setup();
        bongoInput.Setup();
    }

    #endregion

    public void TickBongo()
    {
        if (IsActive)
        {
            if (bongoInput.CheckTouches() && timer.GetTimer() != 0f)
            {
                currentScoreValue = bongoData.GetMaxValue(); // Calcolo dello score
                GameManager.Instance.AddScore(currentScoreValue);
                DeactivateBongo();
            }
            else if (!timer.CheckTimer(markerTime))
            {
                timer.TickTimer();
            }
            else
            {
                DeactivateBongo();
            }
        }
    }

    public void ActivateBongo()
    {
        IsActive = true;
        bongoData.ChangeColor(IsActive);
    }

    private void DeactivateBongo()
    {
        IsActive = false;
        bongoData.ChangeColor(IsActive);
        timer.StopTimer();
    }

    public TierEnum GetBongoTier()
    {
        return bongoData.GetCurrentTier();
    }

    public int GetSpawnPercentage()
    {
        return bongoData.GetSpawnPercentage();
    }
}

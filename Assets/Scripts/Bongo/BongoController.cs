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
    public bool IsActive { get; private set; }

    public void Setup()
    {
        timer = new Timer();
        bongoData.Setup();
        bongoInput.Setup();
    }

    private void Update()
    {
        TickBongo();
    }

    public void ActivateBongo()
    {
        IsActive = true;
        bongoData.ChangeColor(IsActive);
    }

    public void TickBongo()
    {
        if (IsActive)
        {
            if (bongoInput.CheckTouches() && timer.GetTimer() != 0f)
            {
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

    public void DeactivateBongo()
    {
        IsActive = false;
        bongoData.ChangeColor(IsActive);
        timer.StopTimer();
        // Assegnazione dei punti
    }
}

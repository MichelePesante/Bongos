using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BongoManager : MonoBehaviour
{
    [SerializeField]
    private float spawnRatio;
    private Timer timer;
    private List<BongoController> bongos = new List<BongoController>();
    private int rngPerc;

    private void Start()
    {
        Setup();

        foreach (BongoController bongo in bongos)
        {
            bongo.Setup();
        }
    }

    private void Update()
    {
        TickBongoSpawn();
    }

    #region Setup

    private void Setup()
    {
        timer = new Timer();
        bongos = FindObjectsOfType<BongoController>().ToList();
    }

    #endregion

    public void TickBongoSpawn()
    {
        if (timer.CheckTimer(spawnRatio))
        {
            timer.StopTimer();
            rngPerc = Random.Range(1, 101);
            TriggerBongo(SelectRandomBongo());
        }
        timer.TickTimer();
    }

    private BongoController SelectRandomBongo()
    {
        int rngIndex = Random.Range(0, bongos.Count);
        if (bongos[rngIndex].IsActive)
        {
            return SelectRandomBongo();
        }
        else
        {
            switch (bongos[rngIndex].GetBongoTier())
            {
                case TierEnum.Tier_1:
                    return GetBongoWithPercentage(bongos[rngIndex], rngPerc);
                case TierEnum.Tier_2:
                    return GetBongoWithPercentage(bongos[rngIndex], rngPerc);
                case TierEnum.Tier_3:
                    return GetBongoWithPercentage(bongos[rngIndex], rngPerc);
                default:
                    return SelectRandomBongo();
            }
        }
    }

    private void TriggerBongo(BongoController bongo)
    {
        bongo.ActivateBongo();
    }

    private BongoController GetBongoWithPercentage(BongoController bongo, int _rngPerc)
    {
        if (_rngPerc <= bongo.GetSpawnPercentage())
        {
            return bongo;
        }
        else
        {
            return SelectRandomBongo();
        }
    }
}

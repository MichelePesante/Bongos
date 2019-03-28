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
        if (timer.CheckTimer(spawnRatio))
        {
            timer.StopTimer();
            TriggerBongo(SelectRandomBongo());
        }
        timer.TickTimer();
    }

    private void Setup()
    {
        timer = new Timer();
        bongos = FindObjectsOfType<BongoController>().ToList();
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
            return bongos[rngIndex];
        }
    }

    private void TriggerBongo(BongoController bongo)
    {
        bongo.ActivateBongo();
    }
}

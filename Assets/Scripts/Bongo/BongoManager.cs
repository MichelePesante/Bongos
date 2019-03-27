using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BongoManager : MonoBehaviour
{
    List<BongoController> bongos = new List<BongoController>();

    void Start()
    {
        bongos = FindObjectsOfType<BongoController>().ToList();
        foreach (BongoController bongo in bongos)
        {
            bongo.Setup();
        }
    }
}

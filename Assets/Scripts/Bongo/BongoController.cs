using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BongoController : MonoBehaviour
{
    [SerializeField]
    private BongoData bongoData;
    [SerializeField]
    private BongoInput bongoInput;

    public void Setup()
    {
        bongoData.Setup();
        bongoInput.Setup();
    }

    private void Update()
    {
        bongoInput.CheckTouches();
    }
}

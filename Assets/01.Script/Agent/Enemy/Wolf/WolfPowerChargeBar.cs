using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfPowerChargeBar : MonoBehaviour
{
    [SerializeField] private GameObject _gage;
    private float _gageBar;

    private void OnEnable()
    {
        _gage.transform.localScale = new Vector3(0,1,1);
        _gageBar = 0;
    }

    public bool PowerCharge()
    {
        _gageBar += Mathf.Clamp(Time.deltaTime,0,1);
        _gage.transform.localScale = new Vector3(_gageBar, 1, 1);
        if (_gageBar >= 1)
            return true;
        return false;
    }

}

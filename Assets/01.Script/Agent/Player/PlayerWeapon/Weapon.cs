using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour

{
    Player owner;
    public IWeapon currentWeaon;
    private void Awake()
    {
        owner = transform.root.GetComponent<Player>();
    }

    public void SetWeapon()
    {
        currentWeaon = GetComponentInChildren<IWeapon>();
    }

}

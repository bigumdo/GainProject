using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Player owner;

    private void Awake()
    {
        owner = transform.root.GetComponent<Player>();
    }

}

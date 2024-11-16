using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCast : MonoBehaviour
{
    [SerializeField] private float _checkRange;
    [SerializeField] private LayerMask _layerMask;

    public bool CheckRange()
    {
        Collider[] hit;
        hit = Physics.OverlapSphere(transform.position, _checkRange, _layerMask);
        if(hit.Length > 0)
            return true;
        else return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _checkRange);
    }
}

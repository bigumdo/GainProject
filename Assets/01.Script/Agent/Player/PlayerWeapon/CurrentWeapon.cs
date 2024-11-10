using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeapon : MonoBehaviour
{
    private Weapon _weapon;

    private void Awake()
    {
        _weapon = GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Debug.Log(mouse);
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        float angle = Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.AngleAxis(angle, transform.root.right);

    }


}

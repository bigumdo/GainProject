using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeapon : MonoBehaviour
{
    private Weapon _weapon;
    private Agent _owner;

    private void Awake()
    {
        _weapon = GetComponentInChildren<Weapon>();
        _owner = transform.root.GetComponent<Agent>();
    }

    private void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition
            - transform.position);
        //Debug.Log(mouse);
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //Debug.Log(Input.mousePosition);
        float angle = Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg;
        if (Mathf.Abs(angle) > 90)
        {
            _owner.SpriteRendererCompo.flipX = true;
            transform.localScale = new Vector3(-1, -1, 1);
            //transform.root.localScale = new Vector3(-1, 1, 1);

        }
        else
        {

            _owner.SpriteRendererCompo.flipX = false;
            //transform.root.localScale = new Vector3(1, 1, 1);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.localRotation = Quaternion.AngleAxis(angle, transform.forward);

    }


}

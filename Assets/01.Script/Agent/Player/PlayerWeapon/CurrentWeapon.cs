using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeapon : MonoBehaviour
{
    private Weapon _weapon;
    private Player _owner;
    private float mouseDir;
    private void Awake()
    {
        _weapon = GetComponentInChildren<Weapon>();
        _owner = transform.root.GetComponent<Player>();
    }

    private void Update()
    {

        if (!_owner.IsWeaponFlip)
            return;

        mouseDir = GameManager.Instance.MouseAngle;
        if (Mathf.Abs(mouseDir) > 90)
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
        transform.localRotation = Quaternion.AngleAxis(mouseDir, transform.forward);

    }


}

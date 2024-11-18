using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Monosingleton<GameManager>
{
    public Player Player { get; private set; }
    public float MouseAngle { get; private set; }
    public Vector2 MouseDir
    {
        get
        {
            Vector2 playerPos = Player.transform.position; // �÷��̾� ��ġ
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ���콺 ��ġ
            return (mousePos - playerPos).normalized; // ���� ���͸� ��ȯ (ũ�� 1)
        }
    }


    private void Awake()
    {
        Player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        MousePosition();
    }

    private void MousePosition()
    {
        MouseAngle = Mathf.Atan2(MouseDir.y, MouseDir.x) * Mathf.Rad2Deg;
        //if (Mathf.Abs(Mouse) > 90)
        //{
        //    Player.SpriteRendererCompo.flipX = true;
        //    transform.localScale = new Vector3(-1, -1, 1);
        //    //transform.root.localScale = new Vector3(-1, 1, 1);

        //}
        //else
        //{

        //    Player.SpriteRendererCompo.flipX = false;
        //    //transform.root.localScale = new Vector3(1, 1, 1);
        //    transform.localScale = new Vector3(-1, 1, 1);
        //}
        //transform.localRotation = Quaternion.AngleAxis(Mouse, transform.forward);
    }
}

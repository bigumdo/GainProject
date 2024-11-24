using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Player player;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            player.StartMove();
            //Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            player.StopMove();
            //Time.timeScale = 1;
        }
    }
}

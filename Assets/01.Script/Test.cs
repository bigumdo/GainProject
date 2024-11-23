using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {

            Time.timeScale = 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn : MonoBehaviour
{

    public void Close(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    public void Open(GameObject obj)
    {
        obj.gameObject.SetActive(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_DartsTrap : MonoBehaviour
{
    public GameObject dartsProjecile;
    public Transform dispenserObject;
    public void DartFires()
    {
        Instantiate(dartsProjecile, dispenserObject, false);
    }
}

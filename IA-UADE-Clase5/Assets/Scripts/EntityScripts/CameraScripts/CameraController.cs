using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    CameraModel _model;
    private void Awake()
    {
        _model = GetComponent<CameraModel>();
    }
    private void Update()
    {
        if (_model.CheckRange(target) && _model.CheckAngle(target) && _model.CheckView(target))
        {
            _model.SetLights(true);
            //print("Dentro");
        }
        else
        {
            _model.SetLights(false);
            //print("Fuera de la vision");
        }
    }
}

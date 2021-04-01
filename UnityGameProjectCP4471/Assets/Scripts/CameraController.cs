using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject raceCar;
    private Vector3 offset = new Vector3(-1, 5, -11);

    void Update()
    {
        transform.position = raceCar.transform.position + offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject raceCar;
    private Vector3 offset = new Vector3(0, 7, -11);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = raceCar.transform.position + offset;
        
    }
}

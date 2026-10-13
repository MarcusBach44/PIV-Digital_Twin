using System;
using UnityEngine;

public class RotatingSatelite : MonoBehaviour
{
    [SerializeField] public float rotationSpeed = 1f;
    public bool isRotating = false;
    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(new Vector3(0, rotationSpeed*Time.deltaTime, 0), Space.Self);
        }
    }
}

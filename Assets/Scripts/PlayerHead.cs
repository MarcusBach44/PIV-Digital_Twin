using System;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1f;

    private float mouseX, mouseY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }

    private void FixedUpdate()
    {
        float turner = mouseX *sensitivity;
        if (turner != 0)
        {
            transform.eulerAngles += new Vector3(0f, turner, 0f);
        }
        
        float looker = -mouseY *sensitivity;
        if (looker != 0)
        {
            transform.eulerAngles += new Vector3(looker, 0f, 0f);
        }
    }
}

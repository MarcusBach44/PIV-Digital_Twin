using System;
using UnityEngine;

public class RotatingSatelite : MonoBehaviour
{
    [SerializeField] public float rotationSpeed = 1f;
    public bool isRotating = false;
    private Animator  animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            animator.enabled = false;
            transform.Rotate(new Vector3(0, rotationSpeed*Time.deltaTime, 0), Space.Self);
        }
    }

    public void StartSatellite()
    {
        animator.SetBool("Started", true);
    }
}

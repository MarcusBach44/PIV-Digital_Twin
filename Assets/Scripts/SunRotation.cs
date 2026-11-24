using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SunRotation : MonoBehaviour
{
    [SerializeField] private float sunRotationSpeed = 1f;
    [SerializeField] private GameObject rotationPoint;
    [SerializeField] private GameObject lightSource;
    
    private Volume volume;
    private Bloom bloom;
    
    private bool isIncreasing = true;
    public bool isDay = true;
    [SerializeField] private float intensityGrowthSpeed = 0.3f;
    [SerializeField] private float maxIntensity = 250f;

    private void Start()
    {
        volume = GetComponent<Volume>();
        bloom = volume.profile.components[0] as Bloom;
        //mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(rotationPoint.transform.position, Vector3.left, sunRotationSpeed * Time.deltaTime);
        transform.LookAt(rotationPoint.transform);
        lightSource.transform.rotation = transform.rotation;

        if (transform.position.y < 0)
        {
            isDay = false;
            bloom.intensity.value = 0f;
            lightSource.SetActive(false);
        }
        else
        {
            isDay = true;
            lightSource.SetActive(true);
        }
        if (isDay)
        {
            if (isIncreasing)
            {
                bloom.intensity.value += intensityGrowthSpeed*Time.deltaTime;
                if (bloom.intensity.value >= maxIntensity)
                {
                    isIncreasing = false;
                }
            }
            else if (!isIncreasing)
            {
                bloom.intensity.value -= intensityGrowthSpeed*Time.deltaTime;
                if (bloom.intensity.value <= 0f)
                {
                    isIncreasing = true;
                }
            }
        }
       
    }
    
}

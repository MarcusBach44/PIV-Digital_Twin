using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SunRotation : MonoBehaviour
{
    [SerializeField] private float sunRotationSpeed = 1f;

    [SerializeField] private GameObject rotationPoint;

    [SerializeField] private GameObject LightSource;
    
    private Volume volume;
    private Bloom bloom;
    private Material mat;
    
    private bool isIncreasing = true;
    public bool isDay = true;
    [SerializeField] private float intensityGrowthSpeed = 0.3f;
    [SerializeField] private float maxIntensity = 250f;

    private void Start()
    {
        volume = GetComponent<Volume>();
        bloom = volume.profile.components[0] as Bloom;
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(rotationPoint.transform.position, Vector3.left, sunRotationSpeed * Time.deltaTime);
        transform.LookAt(rotationPoint.transform);
        LightSource.transform.rotation = transform.rotation;

        if (transform.position.y < 0)
        {
            isDay = false;
            //bloom.intensity.value = 0f;
            //mat.DisableKeyword("_EMISSION");
            LightSource.SetActive(false);
        }
        else
        {
            isDay = true;
            mat.EnableKeyword("_EMISSION");
            LightSource.SetActive(true);
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

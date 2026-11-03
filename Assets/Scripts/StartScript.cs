using System;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject canvas;
    private bool isStarted = false;
    private float counter = 3;
    private GameObject cameraPoint;

    public void onStart()
    {
        cameraPoint = player.transform.GetChild(0).gameObject;
        isStarted = true;
        player.GetComponent<PlayerHead>().enabled = true;
    }
    
    private void Update()
    {
        if (isStarted)
        {
             
            camera.transform.position =
                Vector3.Lerp(camera.transform.position, cameraPoint.transform.position, 3 * Time.deltaTime);
            camera.transform.rotation = 
                Quaternion.Lerp(camera.transform.rotation, cameraPoint.transform.rotation, 3 * Time.deltaTime);
            
            counter -= Time.deltaTime;
            if (counter < 0)
            {
                isStarted = false;
                canvas.SetActive(false);
            }
        }
        
    }
}


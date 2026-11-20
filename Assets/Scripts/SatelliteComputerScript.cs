using System;
using TMPro;
using UnityEngine;

public class SatelliteComputerScript : MonoBehaviour
{
    [SerializeField] private Material screenDone, screenFail;
    [SerializeField] private GameObject satellite;
    [SerializeField] private TMP_Text screenText;
    [SerializeField] private GameObject commScreen;
    [SerializeField] private int screenNumber;
    private Renderer rend;
    private int counter = 0;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        screenText.text = "Press Button To Turn Satellite On";
    }

    private void Update()
    {
        if (rend.material != screenDone && counter ==0)
        {
            if (satellite.GetComponent<RotatingSatelite>().isRotating)
            {
                rend.material = screenDone;
                commScreen.gameObject.GetComponent<CommunicationComputer>().TurnOnScreen(screenNumber);
                screenText.text = "Satellite Ready For Communication";
                counter++;
            }
        }
    }

    public void Interact()
    {
        rend.material = screenFail;
        satellite.GetComponent<RotatingSatelite>().StartSatellite();
        screenText.text = "Error: Satellite Stuck";
    }
}

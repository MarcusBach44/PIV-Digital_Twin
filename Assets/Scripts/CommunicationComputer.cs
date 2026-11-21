using System.Collections;
using TMPro;
using UnityEngine;

public class CommunicationComputer : MonoBehaviour
{
    [SerializeField] private GameObject satelliteScreen0, satelliteScreen1, button;
    private Renderer rend_satelliteScreen0, rend_satelliteScreen1;

    [SerializeField] private GameObject rocket;
    
    [SerializeField] private TMP_Text screenText;
    
    [SerializeField] private Material green, white;
    
    public bool canEstablishLink = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend_satelliteScreen0 = satelliteScreen0.GetComponent<Renderer>();
        rend_satelliteScreen1 = satelliteScreen1.GetComponent<Renderer>();
        screenText.text = "No Connection";
    }
    
    public void TurnOnScreen(int screenNumber)
    {
        switch (screenNumber)
        {
            case 0:
                rend_satelliteScreen0.material = green;
                break;
            case 1:
                rend_satelliteScreen1.material = green;
                break;
        }
        if (rend_satelliteScreen0.material.name == "ScreenGreen (Instance)" && rend_satelliteScreen1.material.name == "ScreenGreen (Instance)")
        {
            screenText.text = "Press To Establish L I N K";
            button.GetComponent<Renderer>().material = white;
            canEstablishLink = true;
        }
    }

    public void EstablishLink()
    {
        StartCoroutine(Cutscene());
    }


    IEnumerator Cutscene()
    {
        screenText.text = "Establishing Link";
        
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1);
            screenText.text += ".";
        }
        yield return new WaitForSeconds(1);
        screenText.text = "Link Established \n Help Inbound";
        rocket.SetActive(true);
    }
}

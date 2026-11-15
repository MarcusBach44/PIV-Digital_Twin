using UnityEngine;

public class PowerCubeComputer : MonoBehaviour
{
    [SerializeField] private GameObject powerCubeGameController;
    [SerializeField] private Material screenOn,screenGreen;
    
    public void Interact()
    {
        if (gameObject.GetComponent<Renderer>().material.color == Color.white)
        {
            gameObject.GetComponent<Renderer>().material = screenGreen;
            powerCubeGameController.GetComponent<PowerCubeMinigameScript>().NextScreen();
        }
            
    }
}

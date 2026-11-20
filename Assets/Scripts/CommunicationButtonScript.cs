using UnityEngine;

public class CommunicationButtonScript : MonoBehaviour
{
    [SerializeField] private Material green;
    [SerializeField] private CommunicationComputer commPC;
    
    public void Interact()
    {
        if (commPC.canEstablishLink)
        {
            gameObject.GetComponent<Renderer>().material = green;
            commPC.EstablishLink();
        }
        
    }
}

using System;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private Material open, close;
    [SerializeField] private GameObject door;

    [SerializeField] private GeneratorScript  generatorScript;
    private DoorScript doorScript;
    private Renderer renderer;
    public bool isOpen;
    private bool start = true;

    private void Start()
    {
        doorScript = door.GetComponent<DoorScript>();
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (!generatorScript.isPowerOn)
        {
            return;
        }
        if (start)
        {
            renderer.material = close;
            start = false;
        }
    }

    public void OpenDoor()
    {
        if (!generatorScript.isPowerOn)
        {
            return;
        }
        doorScript.OpenDoor();
        isOpen = true;
        renderer.material = open;
    }

    public void CloseDoor()
    {
        if (!generatorScript.isPowerOn)
        {
            return;
        }
        doorScript.CloseDoor();
        isOpen = false;
        renderer.material = close;
    }
}

using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PowerCubeMinigameScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> screens;
    [SerializeField] private Material off, on, done;
    
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        GameObject startScreen = screens[Random.Range(0, screens.Count)];
        startScreen.GetComponent<Renderer>().material = on;
        screens.Remove(startScreen);
    }

    public void NextScreen()
    {
        if (screens.Count == 0)
        {
            UnlockPowerCube();
            return;
        }
        GameObject nextScreen = screens[Random.Range(0, screens.Count)];
        nextScreen.GetComponent<Renderer>().material = on;
        screens.Remove(nextScreen);
    }

    void UnlockPowerCube()
    {
        animator.SetBool("Unlocked", true);
    }
}

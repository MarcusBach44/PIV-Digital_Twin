using UnityEngine;

public class RotatingSatelite : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;
    private Transform satelite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        satelite = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        satelite.Rotate(new Vector3(0, rotationSpeed*Time.deltaTime, 0), Space.Self);
    }
}

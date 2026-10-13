using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject playerHead;
    [SerializeField] private float headHeight = 1;
    
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float gravity = 10f;
    
    private float horizontal, vertical;
    Transform bodyTransform;
    CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.zero;

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(horizontal, 0f, vertical);
            moveDirection = this.transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        
        playerHead.transform.position = this.transform.position + new Vector3(0f, headHeight, 0f);
        this.transform.eulerAngles = new Vector3(0f, playerHead.transform.rotation.eulerAngles.y, 0f);
    }
}

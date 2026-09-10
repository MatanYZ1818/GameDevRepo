using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject PlayerCamera;
    private float speed = 3;
    public float runMultiplier = 2f;
    float angularSpeed = 250;
    CharacterController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>(); //initialization of component
    }

    // Update is called once per frame
    void Update()
    {
        float dx = 0, dz = 0;
        float RotationAboutY = Input.GetAxis("Mouse X") * angularSpeed * Time.deltaTime;
        float RotationAboutX = Input.GetAxis("Mouse Y") * 0.5f * angularSpeed * Time.deltaTime;

        PlayerCamera.transform.Rotate(new Vector3(-RotationAboutX, 0, 0));
        transform.Rotate(new Vector3(0, RotationAboutY, 0));

        // Determine current speed based on whether Shift is held down
        float currentSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed *= runMultiplier;
        }

        dz = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
        dx = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;

        Vector3 motion = new Vector3(dx, -1, dz);
        motion = transform.TransformDirection(motion);
        controller.Move(motion);
    }
}

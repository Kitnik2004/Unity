//Накладывается на объект ракеты
using UnityEngine;

public class Movement : MonoBehaviour
{
    private GameObject player;
    private GameObject lJoy;
    private GameObject rJoy;
    private Vector3 lJoyDirection;
    private Vector3 rJoyDirection;
    private GameObject camera;
    public int speed;
    public int cameraSpeed;
    void Start()
    {
        player = gameObject;
        camera = GameObject.Find("Main Camera");
        lJoy = GameObject.Find("Left Joystick");
        rJoy = GameObject.Find("Right Joystick");
    }

    void Update()
    {
        rJoyDirection = rJoy.GetComponent<Joystick>().direction;
        lJoyDirection = lJoy.GetComponent<Joystick>().direction;
        Turn();
        Move();
    }
    void Turn()
    {
        float y = rJoyDirection.x * cameraSpeed * Time.deltaTime;
        player.transform.Rotate(0, y, 0);
    }

    void Move()
    {
        Vector3 camForward = camera.transform.forward;
        Vector3 camRight = camera.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();
        Vector3 moveDirection = (camForward * lJoyDirection.y + camRight * lJoyDirection.x).normalized;
        player.GetComponent<Rigidbody>().AddForce(moveDirection * Time.deltaTime * speed);
        player.GetComponent<Rigidbody>().AddForce(0, rJoyDirection.y * Time.deltaTime * speed, 0);
    }
}

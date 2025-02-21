using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public GameObject lJoy;
    public GameObject rJoy;
    public Vector3 lJoyDirection;
    public Vector3 rJoyDirection;
    [SerializeField] GameObject camera;
    public int speed;
    public int cameraSpeed;
    void Start()
    {
        player = gameObject;
        lJoy = GameObject.Find("Left Joystick");
        rJoy = GameObject.Find("Right Joystick");
    }

    // Update is called once per frame
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
        player.transform.Translate(Vector3.forward * lJoyDirection.y * Time.deltaTime * speed);
        player.transform.Translate(Vector3.right * lJoyDirection.x * Time.deltaTime * speed);
        player.transform.position += new Vector3(0, rJoyDirection.y, 0) * Time.deltaTime * speed;
    }
}

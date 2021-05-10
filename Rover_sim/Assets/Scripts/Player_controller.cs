using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    [SerializeField]
    KeyCode KeyPositive_rotate;
    [SerializeField]
    KeyCode KeyNegative_rotate;
    [SerializeField]
    KeyCode KeyReset_rotate;
    [SerializeField]
    KeyCode audioController;
    [SerializeField]
    AudioSource UnderWater_audio;
    private bool u_play = true;

    public float forwardSpeed = 7.5f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float activeForwardSpeed, activeStrafSpeed, activeHaverSpeed;
    private float forwardAcceleration = 2f, strafeAcceleration = 2f, hoverAccleration = 2f;

    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    private GameObject player;

    Rigidbody playerRigidBody;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigidBody = player.GetComponent<Rigidbody>();

        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;

        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        if (Input.GetKeyDown(audioController))
        {
            if (u_play == true)
            {
                UnderWater_audio.Stop();
                u_play = false;
            }
            else
            {
                UnderWater_audio.Play();
            }
        }
        if (Input.GetKey(KeyPositive_rotate))
        {
            //rd.drag = 0.0f;
            transform.Rotate(-Vector3.up * lookRateSpeed * Time.deltaTime);

        }
        else if (Input.GetKey(KeyNegative_rotate))
        {
            //rd.drag = 0.0f;
            transform.Rotate(Vector3.up * lookRateSpeed * Time.deltaTime);

        }
        else if (Input.GetKey(KeyReset_rotate))
        {
            Vector3 eulerRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
        }
        if (Input.GetMouseButton(0))
        {
            lookInput.x = Input.mousePosition.x;
            lookInput.y = Input.mousePosition.y;

            // playerRigidBody.constraints = RigidbodyConstraints.FreezeRotationZ;

            mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
            mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

            mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

            transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, 0f, Space.Self);
        }
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafSpeed = Mathf.Lerp(activeStrafSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHaverSpeed = Mathf.Lerp(activeHaverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAccleration * Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += (transform.right * activeStrafSpeed * Time.deltaTime) + (transform.up * activeHaverSpeed * Time.deltaTime);
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}

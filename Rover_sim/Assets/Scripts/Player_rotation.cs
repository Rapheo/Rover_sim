using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_rotation : MonoBehaviour
{
    [SerializeField]
    KeyCode KeyPositive1;
    [SerializeField]
    KeyCode KeyNegative1;
    [SerializeField]
    float RotateSpeed = 30.0f;

    private Rigidbody rd1;

    private void Start()
    {
        rd1 = GetComponent<Rigidbody>();
        rd1.drag = 0.5f;
    }

    void Update()
    {

        if (Input.GetKey(KeyPositive1))
        {
            //rd.drag = 0.0f;
            transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);

        }
        else if (Input.GetKey(KeyNegative1))
        {
            //rd.drag = 0.0f;
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);

        }
        else
        {
            //rd.drag = 0.5f;
        }
    }
}

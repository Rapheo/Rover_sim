using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_Player_Controlled_Velocity : MonoBehaviour
{

    [SerializeField]
    Vector3 v3Force;
    [SerializeField]
    KeyCode KeyPositive;
    [SerializeField]
    KeyCode KeyNegative;
    [SerializeField]
    float speed = 1.0f;
    
    private Rigidbody rd;

    private void Start()
    {
        rd = GetComponent<Rigidbody>();
        rd.drag = 0.5f;
    }

    void Update()
    {

        if (Input.GetKey(KeyPositive))
        {
            //rd.drag = 0.0f;
            rd.velocity += v3Force;

        }
        else if (Input.GetKey(KeyNegative))
        {
                //rd.drag = 0.0f;
                rd.velocity -= v3Force;
  
        }
        else {
            //rd.drag = 0.5f;
        }
    }
}

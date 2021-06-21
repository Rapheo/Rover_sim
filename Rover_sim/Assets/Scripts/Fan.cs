using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fan : MonoBehaviour
{
    [SerializeField]
    KeyCode forward;
    [SerializeField]
    KeyCode backward;
    [SerializeField]
    KeyCode left;
    [SerializeField]
    KeyCode right;
    [SerializeField]
    KeyCode right_strafe;
    [SerializeField]
    KeyCode left_strafe;
    [SerializeField]
    KeyCode up;
    [SerializeField]
    KeyCode down;

    [SerializeField]
    float[] rotation_speed = new float[7];
    [SerializeField]
    float speedup_rate = 0f;

    bool forward_rotate_status = false;
    bool backward_rotate_status = false;
    bool left_rotate_status = false;
    bool right_rotate_status = false;
    bool up_rotate_status = false;
    bool down_rotate_status = false;
    bool left_strafe_status = false;
    bool right_strafe_status = false;




    //[SerializeField]
    //float rotation_speed = 2.5f;
    //[SerializeField]
    //float rotation_friction = 1f;
    //[SerializeField]
    //float rotation_smothness = 5f;


    GameObject fan_1_left;
    GameObject fan_2_left;
    GameObject fan_3_left;
    GameObject fan_1_right;
    GameObject fan_2_right;
    GameObject fan_3_right;

    //private Quaternion Quaternion_Rotate_From;
    //private Quaternion Quaternion_Rotate_To;
    //private float rotate_value;


    private void Start()
    {
        fan_1_left = GameObject.FindWithTag("Fan_1_Left");
        fan_2_left = GameObject.FindWithTag("Fan_2_Left");
        fan_3_left = GameObject.FindWithTag("Fan_3_Left");
        fan_1_right = GameObject.FindWithTag("Fan_1_Right");
        fan_2_right = GameObject.FindWithTag("Fan_2_Right");
        fan_3_right = GameObject.FindWithTag("Fan_3_Right");
    }
    void Update()
    {
        if (Input.GetKey(forward)) {
          if (rotation_speed[0] <= 10000f) {
                rotation_speed[0] += speedup_rate;
            }
            forward_rotate_status = true;
            forward_rotate();
        }
        if (!Input.GetKey(forward) && rotation_speed[0] > 0f && forward_rotate_status) {
            rotation_speed[0] -= (speedup_rate - 65f);
            forward_rotate();
            if (rotation_speed[0] == 0) {
                forward_rotate_status = false;
            }
        }

        if (Input.GetKey(backward))
        {
            if (rotation_speed[1] <= 10000f)
            {
                rotation_speed[1] += speedup_rate;
            }
            backward_rotate_status = true;
            backward_rotate();
        }
        if (!Input.GetKey(backward) && rotation_speed[1] > 0f && backward_rotate_status)
        {
            rotation_speed[1] -= (speedup_rate - 65f);
            backward_rotate();
            if (rotation_speed[1] == 0)
            {
                backward_rotate_status = false;
            }
        }

        if (Input.GetKey(left))
        {
            if (rotation_speed[2] <= 10000f)
            {
                rotation_speed[2] += speedup_rate;
            }
            left_rotate_status = true;
            Left_rotate();
        }
        if (!Input.GetKey(left) && rotation_speed[2] > 0f && left_rotate_status)
        {
            rotation_speed[2] -= (speedup_rate - 65f);
            Left_rotate();
            if (rotation_speed[2] == 0)
            {
                left_rotate_status = false;
            }
        }

        if (Input.GetKey(right))
        {
            if (rotation_speed[3] <= 10000f)
            {
                rotation_speed[3] += speedup_rate;
            }
            right_rotate_status = true;
            Right_rotate();
        }
        if (!Input.GetKey(right) && rotation_speed[3] > 0f && right_rotate_status)
        {
            rotation_speed[3] -= (speedup_rate - 65f);
            Right_rotate();
            if (rotation_speed[3] == 0)
            {
                right_rotate_status = false;
            }
        }

        if (Input.GetKey(up))
        {
            if (rotation_speed[4] <= 10000f)
            {
                rotation_speed[4] += 300f;
            }
            up_rotate_status = true;
            up_rotate();
        }
        if (!Input.GetKey(up) && rotation_speed[4] > 0f && up_rotate_status)
        {
            rotation_speed[4] -= 100f;
            up_rotate();
            if (rotation_speed[4] == 0)
            {
                up_rotate_status = false;
            }
        }

        if (Input.GetKey(down))
        {
            if (rotation_speed[5] <= 10000f)
            {
                rotation_speed[5] += 300f;
            }
            down_rotate_status = true;
            down_rotate();
        }
        if (!Input.GetKey(down) && rotation_speed[5] > 0f && down_rotate_status)
        {
            rotation_speed[5] -= 100f;
            down_rotate();
            if (rotation_speed[5] == 0)
            {
                down_rotate_status = false;
            }
        }

        if (Input.GetKey(left_strafe))
        {
            if (rotation_speed[6] <= 10000f)
            {
                rotation_speed[6] += 300f;
            }
            left_strafe_status = true;
            left_strafe_rotate();
        }
        if (!Input.GetKey(left_strafe) && rotation_speed[6] > 0f && left_strafe_status)
        {
            rotation_speed[6] -= 100f;
            left_strafe_rotate();
            if (rotation_speed[6] == 0)
            {
                left_strafe_status = false;
            }
        }

        if (Input.GetKey(right_strafe))
        {
            if (rotation_speed[7] <= 10000f)
            {
                rotation_speed[7] += 300f;
            }
            right_strafe_status = true;
            right_strafe_rotate();
        }
        if (!Input.GetKey(right_strafe) && rotation_speed[7] > 0f && right_strafe_status)
        {
            rotation_speed[7] -= 100f;
            right_strafe_rotate();
            if (rotation_speed[7] == 0)
            {
                right_strafe_status = false;
            }
        }

        //if (Input.GetKey(forward)) {
        //    if (rotate_value == 360) {
        //        rotate_value = 0;
        //    }
        //    rotate_value++;
        //    rotate_value = rotation_speed * rotation_friction;
        //    forward_rotate();
        //}
    }

    public void forward_rotate() {
        fan_1_left.transform.Rotate(0,0, rotation_speed[0] * Time.deltaTime);
        fan_1_right.transform.Rotate(0, 0, rotation_speed[0] * Time.deltaTime);
        fan_3_left.transform.Rotate(0, 0, rotation_speed[0] * Time.deltaTime);
        fan_3_right.transform.Rotate(0, 0, rotation_speed[0] * Time.deltaTime);
        //float x = fan_1_left.transform.rotation.x;
        //float y = fan_1_left.transform.rotation.y;
        //Quaternion_Rotate_From = fan_1_left.transform.localRotation;
        //Quaternion_Rotate_To = Quaternion.Euler(0,0, rotate_value);
        //fan_1_left.transform.rotation = Quaternion.Lerp(Quaternion_Rotate_From, Quaternion_Rotate_To, Time.deltaTime * rotation_smothness);
        //fan_1_left.transform.Rotate(x, 30.51f, fan_1_left.transform.rotation.z); 


        //Quaternion_Rotate_From = fan_1_right.transform.rotation;
        //Quaternion_Rotate_To = Quaternion.Euler(0, 0, rotate_value);
        //fan_1_right.transform.rotation = Quaternion.Lerp(Quaternion_Rotate_From, Quaternion_Rotate_To, Time.deltaTime * rotation_smothness);
    }
    public void backward_rotate()
    {
        fan_1_left.transform.Rotate(0, 0, -rotation_speed[1] * Time.deltaTime);
        fan_1_right.transform.Rotate(0, 0, -rotation_speed[1] * Time.deltaTime);
        fan_3_left.transform.Rotate(0, 0, -rotation_speed[1] * Time.deltaTime);
        fan_3_right.transform.Rotate(0, 0, -rotation_speed[1] * Time.deltaTime);
    }

    public void Left_rotate()
    {
        fan_1_left.transform.Rotate(0, 0, rotation_speed[2] * Time.deltaTime);
        fan_3_left.transform.Rotate(0, 0, -rotation_speed[2] * Time.deltaTime);
    }
    public void Right_rotate()
    {
        fan_1_right.transform.Rotate(0, 0, rotation_speed[3] * Time.deltaTime);
        fan_3_right.transform.Rotate(0, 0, -rotation_speed[3] * Time.deltaTime);
    }
    public void up_rotate()
    {
        fan_2_left.transform.Rotate(0, 0, -rotation_speed[4] * Time.deltaTime);
        fan_2_right.transform.Rotate(0, 0, rotation_speed[4] * Time.deltaTime);
    }
    public void down_rotate()
    {
        fan_2_left.transform.Rotate(0, 0, rotation_speed[5] * Time.deltaTime);
        fan_2_right.transform.Rotate(0, 0, -rotation_speed[5] * Time.deltaTime);
    }
    public void left_strafe_rotate()
    {
        fan_1_right.transform.Rotate(0, 0, rotation_speed[6] * Time.deltaTime);
    }
    public void right_strafe_rotate()
    {
        fan_1_left.transform.Rotate(0, 0, rotation_speed[7] * Time.deltaTime);
    }


}

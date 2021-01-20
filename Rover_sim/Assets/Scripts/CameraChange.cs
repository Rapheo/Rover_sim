using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField]
    KeyCode CamChange;

    public GameObject ThirdCam;
    public GameObject FirstCam;
    public int CamMode = 0;

    void Update()
    {
        if (Input.GetKeyDown(CamChange)) {
            if (CamMode == 1)
            {
                CamMode = 0;
            }
            else {
                CamMode += 1;
            }
            StartCoroutine(CamChanger());
        }
    }

    IEnumerator CamChanger() { 
        yield return new WaitForSeconds(0.01f);
        if (CamMode == 1) {
            ThirdCam.SetActive(true);
            FirstCam.SetActive(false);
        }
        if (CamMode == 0) {
            FirstCam.SetActive(true);
            ThirdCam.SetActive(false);
        }
    }

}

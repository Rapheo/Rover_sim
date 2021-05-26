using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField]
    KeyCode CamChange;

    public GameObject ThirdCam;
    public GameObject FirstCam;
    public GameObject Free_Cam;
    public int CamMode = 1;


    private void Start()
    {
        Free_Cam.SetActive(false);
        FirstCam.SetActive(false);
        ThirdCam.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(CamChange)) {
            if (CamMode == 2)
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
            Free_Cam.SetActive(false);
        }
        if (CamMode == 0) {
            FirstCam.SetActive(true);
            ThirdCam.SetActive(false);
            Free_Cam.SetActive(false);
        }
        if (CamMode == 2)
        {
            Free_Cam.SetActive(true);
            FirstCam.SetActive(false);
            ThirdCam.SetActive(false);
        }

    }

}

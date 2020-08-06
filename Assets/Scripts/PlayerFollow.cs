using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public float sensitivity;
    public float dist;
    public float height;
    public Transform target;
    public Transform cam_tr;
    private Vector3 offset;
    /* Camera Rotation Speed */
    public float rotateSpeed;

    void Start()
    {   
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
        cam_tr = GetComponent<Transform>();
        offset = new Vector3(dist, height, 0);
    }

    void Update()
    {
        float dx = Input.GetAxis("Mouse X");
        float dy = Input.GetAxis("Mouse Y");
        float dx_rotate = Input.GetAxis("Mouse X");
        float dy_rotate = Input.GetAxis("Mouse Y");

        target.Rotate(0, dy_rotate, 0);
        offset = Quaternion.AngleAxis(dx * sensitivity, Vector3.up) * offset;
        offset = Quaternion.AngleAxis(-dy * sensitivity, cam_tr.right) * offset;
        cam_tr.position = target.position + offset;
        cam_tr.LookAt(target);
    }

    void LateUpdate()
    {

    }

}

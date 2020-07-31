using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public float sensitivity = 2.5f;
    public float dist = 10f;
    public float height = 5f;
    public Transform target;
    public Transform tr;

    void Start()
    {
        Cursor.visible = false;
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        tr = Camera.main.transform;        
        tr.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        tr.Rotate(-Input.GetAxis("Mouse Y") * sensitivity, 0, 0);
        if(Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate(){
        float currYAngle = Mathf.LerpAngle(tr.eulerAngles.y, target.eulerAngles.y, sensitivity * Time.deltaTime);
        Quaternion rot = Quaternion.Euler(0, currYAngle, 0);
        tr.position = target.position - (rot * Vector3.forward * dist) + (Vector3.up * height);
        // tr.LookAt(target);
    }
}

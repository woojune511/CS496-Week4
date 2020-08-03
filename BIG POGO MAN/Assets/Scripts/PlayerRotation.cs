using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    // public float sensitivity;
    // public float dist;
    // public float height;
    public Transform target;
    public Transform player_tr;
    // private Vector3 offset;

    void Start()
    {

    }

    void Update()
    {
        float dx = Input.GetAxis("Mouse X");
        float dy = Input.GetAxis("Mouse Y");

        // Debug.Log($"Camera Angle: {target.eulerAngles}    Player Angle: {player_tr.eulerAngles}");

        player_tr.rotation = Quaternion.Euler(new Vector3(0, target.eulerAngles.y - 90, 0));

    }

    void LateUpdate(){

    }
}

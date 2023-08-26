using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float rotSpeed = 15.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotationPlayer();
    }
    void RotationPlayer()
    {
        Vector3 movement = Vector3.zero;

        //rotation Player
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");

        if (horInput != 0 || verInput != 0)
        {
            movement.x = horInput;
            movement.z = verInput;

            Quaternion tmp = target.rotation;
            target.eulerAngles = new Vector3(0, target.rotation.y, 0);
            movement = target.TransformDirection(movement);
            target.rotation = tmp;

            // transform.rotation = Quaternion.LookRotation(movement);
            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private CharacterController character;
    private float axisX;
    private float axisZ;
    private float moveSpeed;
    private void Awake()
    {
        moveSpeed = 5f;
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        
    }
    private void Move()
    {
        axisX = Input.GetAxis("Horizontal");
        axisZ = Input.GetAxis("Vertical");
        Vector3 moveInput = new Vector3(axisX, 0, axisZ);
        character.Move(moveInput * moveSpeed * Time.deltaTime);
    }
}

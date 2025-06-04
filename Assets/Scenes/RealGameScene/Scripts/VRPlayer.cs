using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRPlayer : MonoBehaviour
{
    private static VRPlayer instance = null;

    [SerializeField] private InputActionProperty jumpButton;
    [SerializeField] private float jumpheight = 3f;
    [SerializeField] private CharacterController cc;
    [SerializeField] private LayerMask groundLayers;

    private float gravity = Physics.gravity.y;
    private Vector3 movement;

    void Start()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        bool _isGrounded = IsGrounded();
        if(IsGrounded())
            Debug.Log("∂•π‚∞Ì¿÷¿Ω");
        if (jumpButton.action.WasPressedThisFrame() && _isGrounded && TestPlayer.isPlayerJump && TestPlayer.isPlayerMove)
        {
            Debug.Log("¡°«¡");
            Jump();
        }

        movement.y += gravity * Time.deltaTime;

        cc.Move(movement * Time.deltaTime);
    }

    private void Jump()
    {
        movement.y = Mathf.Sqrt(jumpheight * -3.0f * gravity);
    }
    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 1.4f, groundLayers);
    }
}

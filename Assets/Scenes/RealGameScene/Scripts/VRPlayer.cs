using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VRPlayer : MonoBehaviour
{
    private static VRPlayer instance = null;
    [Header("OculusButton")]
    [SerializeField] private InputActionProperty jumpButton;
    [SerializeField] private InputActionProperty runButton;
    [SerializeField] private InputActionProperty useItemButton;
    [SerializeField] private InputActionProperty menuItemButton;
    [SerializeField] private InputActionProperty menuOptionButton;

    [Header("Element")]
    [SerializeField] private float jumpheight = 3f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private CharacterController cc;
    [SerializeField] private LayerMask groundLayers;

    [Header("Panel")]
    [SerializeField] private GameObject useItemPanel;
    [SerializeField] private GameObject itemMenuPanel;
    [SerializeField] private GameObject optionMenuPanel;

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
            Debug.Log("땅밟고있음");
        if (jumpButton.action.WasPressedThisFrame() && _isGrounded && TestPlayer.isPlayerJump && TestPlayer.isPlayerMove)
        {
            Debug.Log("점프");
            Jump();
        }
        if(runButton.action.IsPressed() && TestPlayer.isPlayerJump && TestPlayer.isPlayerMove)
        {
            Run();
        }
        else
        {
            gameObject.GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 3f;
        }
        if(useItemButton.action.WasPressedThisFrame() && !itemMenuPanel.activeSelf && !optionMenuPanel.activeSelf)
        {
            useItemPanel.SetActive(!useItemPanel.activeSelf);
        }
        if (menuItemButton.action.WasPressedThisFrame() && !useItemPanel.activeSelf && !optionMenuPanel.activeSelf)
        {
            itemMenuPanel.SetActive(!itemMenuPanel.activeSelf);
        }
        if (menuOptionButton.action.WasPressedThisFrame())
        {
            Debug.Log("메뉴버튼 클릭");
            optionMenuPanel.SetActive(!optionMenuPanel.activeSelf);
        }
        movement.y += gravity * Time.deltaTime;

        cc.Move(movement * Time.deltaTime);
    }

    private void Jump()
    {
        movement.y = Mathf.Sqrt(jumpheight * -3.0f * gravity);
        SoundManager.Instance.Play("Jump");
    }

    private void Run()
    {
        gameObject.GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = runSpeed;
        SoundManager.Instance.Play("Run");
    }
    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 1.4f, groundLayers);
    }
}

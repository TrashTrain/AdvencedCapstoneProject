using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VRPlayer : MonoBehaviour
{
    public static VRPlayer instance = null;
    [Header("OculusButton")]
    [SerializeField] private InputActionProperty jumpButton;
    [SerializeField] private InputActionProperty runButton;
    [SerializeField] private InputActionProperty useItemButton;
    [SerializeField] public InputActionProperty menuItemButton;
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


    public PlayerState changeState;
    public PlayerState nowState = PlayerState.WALK;

    public GameObject tiger;

    public bool hit = false;

    public FadeScreen fadeScreen;

    public bool checkStartScene = false;
    private float gravity = Physics.gravity.y;
    private Vector3 movement;

    [Header("BloodScreen")]
    [SerializeField] private GameObject bloodScreen;

    public enum PlayerState
    {
        WALK,
        RUN,
        JUMP,
        HIDE
    }
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
        if (menuOptionButton.action.WasPressedThisFrame())
        {
            //Debug.Log("메뉴버튼 클릭");
            optionMenuPanel.SetActive(!optionMenuPanel.activeSelf);
        }
        if (checkStartScene)
            return;
        bool _isGrounded = IsGrounded();
        if (IsGrounded())
        {
            SoundManager.Instance.Play("Jump");
        }
            //Debug.Log("땅밟고있음");
        if (jumpButton.action.WasPressedThisFrame() && _isGrounded && TestPlayer.isPlayerJump && TestPlayer.isPlayerMove)
        {
            Debug.Log("점프");
            changeState = PlayerState.JUMP;
            Jump();
        }
        if(runButton.action.IsPressed() && TestPlayer.isPlayerJump && TestPlayer.isPlayerMove)
        {
            if (tiger != null)
            {
                if (!tiger.GetComponent<Tiger>().isAttack)
                {
                    Debug.Log("run");
                    changeState = PlayerState.RUN;
                    SoundManager.Instance.Play("Run");
                    Run();
                }
            }
            else
            {
                Debug.Log("run");
                changeState = PlayerState.RUN;
                SoundManager.Instance.Play("Run");
                Run();
            }
            
            
        }
        else
        {
            if (tiger != null)
            {
                if (!tiger.GetComponent<Tiger>().isAttack)
                {
                    Debug.Log("walk");
                    SoundManager.Instance.Stop("Run");
                    changeState = PlayerState.WALK;
                    gameObject.GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 3f;
                }
            }
            else
            {
                Debug.Log("walk");
                SoundManager.Instance.Stop("Run");
                changeState = PlayerState.WALK;
                gameObject.GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 3f;
            }
                    
        }
        if(useItemButton.action.WasPressedThisFrame() && !itemMenuPanel.activeSelf && !optionMenuPanel.activeSelf)
        {
            useItemPanel.SetActive(!useItemPanel.activeSelf);
        }
        if (menuItemButton.action.WasPressedThisFrame() && !useItemPanel.activeSelf && !optionMenuPanel.activeSelf)
        {
            itemMenuPanel.SetActive(!itemMenuPanel.activeSelf);
        }
        
        movement.y += gravity * Time.deltaTime;

        cc.Move(movement * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tiger")
        {
            bloodScreen.GetComponent<BloodScreen>().TakeDamage();
            if (bloodScreen.GetComponent<BloodScreen>().playercurrentHealth <= 0)
            {
                fadeScreen.FadeOut();
                GameMgr.Instance.SceneFastLoader("DieScene");
            }
        }
    }
    private void Jump()
    {
        movement.y = Mathf.Sqrt(jumpheight * -3.0f * gravity);
    }

    // 사운드 중복 방지
    private bool isRunning = false; 
    private void Run()
    {
        gameObject.GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = runSpeed;
    }
    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 1.4f, groundLayers);
    }
}

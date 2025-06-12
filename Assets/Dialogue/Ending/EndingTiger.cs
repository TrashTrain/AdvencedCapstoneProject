using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EndingTiger : MonoBehaviour
{
    // 필요 변수 (호랑이 속도, 움직임 상태, 
    private Vector3 spawnPos;

    [Header("TigerStateInfo")]
    public float tigerWalkSpeed;
    public float tigerRunSpeed;
    public float tigerAttackSpeed;
    public float attackDistance = 2f;
    public TState tigerState;

    private Animator animator;

    private NavMeshAgent meshAgent;

    public Transform playerT;

    public enum TState
    {
        Idle,
        Run,
        Attack,
        Eat,
        RunBack
    }

    // Start is called before the first frame update
    void Start()
    {
        tigerState = TState.Run;
        animator = GetComponent<Animator>();
        meshAgent = GetComponent<NavMeshAgent>();
        //playerT = 
    }

    // Update is called once per frame
    void Update()
    {
        if(VRPlayer.instance.bloodScreen.GetComponent<BloodScreen>().playercurrentHealth <= 1 && SceneManager.GetActiveScene().name == "EndingScene")
        {
            gameObject.GetComponent<InteractionEvent>().enabled = true;
            GameMgr.Instance.SlowMotion(0);
        }
        playerT = VRPlayer.instance.transform;
        meshAgent.SetDestination(playerT.position);
        switch (tigerState)
        {
            case TState.Attack:
                Debug.Log("Attack");
                //ScanPlayer();
                TigerAttack();
                break;
        }
        // 이동 테스트
        //animator.SetBool("AttackTiger", false);
    }

    private void TigerAttack()
    {
        meshAgent.velocity = Vector3.zero;
        animator.SetBool("AttackTiger", true);
        //transform.position = tigerT.GetComponent<Transform>().position;
    }
}

using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

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
    [SerializeField] private AnimatorController changeAni;

    private NavMeshAgent meshAgent;

    [HideInInspector]
    public Transform playerT;

    // 호랑이 자동 움직임 변수
    private float updateInterval = 10f;
    private float timeSinceLastUpdate;

    // 범위 스캔 체크 변수
    public int checkRange = 2;
    private int updateCheckRange = 0;

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
       
    }

    // Update is called once per frame
    void Update()
    {

        // 플레이어 좌표를 향해 일정 속도로 달려오기. -> 플레이어와 일정범위 안으로 가까워지면 점프 공격
        // 곶감에 당했을 때 (도망)

        // 떡을 받았을 때 (심취)
        float distance = Vector3.Distance(transform.position, playerT.position);

        // 자동 상태 전환 (혹시 플레이어가 너무 가까워졌는데 상태 갱신이 안 되었을 때 대비)
       
        switch (tigerState)
        {
            case TState.Idle:
                Debug.Log("Idle");
                //GetRandomMove();
                TigerMove();
                break;
            case TState.Run:
                Debug.Log("Run");
              
                TigerRun();
                break;
            case TState.Attack:
                Debug.Log("Attack");
                //ScanPlayer();
                TigerAttack();
                break;
        }
        // 이동 테스트

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "gotgam")
        {
            Debug.Log("곶감에 맞았다!");
            gameObject.GetComponent<Animator>().runtimeAnimatorController = changeAni;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "dduk")
        {
            Debug.Log("떡이다!");
        }
    }

    /*public void OnCheckScanRange()
    {
        var player = GameMgr.Instance.PlayerInit();
        if (updateCheckRange != checkRange)
        {
            switch (checkRange)
            {
                case 0:
                    break;
                case 1:
                    player.SetUpBoundaryLevel();
                    break;
                case 2:
                    player.SetDownBoundaryLevel();
                    break;
            }

            //Debug.Log("CheckRange : " + checkRange);
            updateCheckRange = checkRange;
        }


    }*/

    // 3초마다 새로운 랜덤 위치를 찾아 이동하는 함수
    /*public void GetRandomMove()
    {
        timeSinceLastUpdate += Time.deltaTime;
        OnCheckScanRange();
        if (timeSinceLastUpdate >= updateInterval)
        {
            if (GameMgr.Instance.PlayerInit().GetBoundaryLevel() <= 0)
            {
                Vector3 randPos = GetRandomPosition();
                meshAgent.SetDestination(randPos);
                timeSinceLastUpdate = 0f;
            }
            else
            {
                meshAgent.SetDestination(playerT.position);
                timeSinceLastUpdate = 0f;
            }
        }
    }
*/
    public Vector3 GetRandomPosition()
    {
        Vector3 randDirect = Random.insideUnitSphere * 20f;
        randDirect += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randDirect, out hit, 20f, NavMesh.AllAreas))
        {
            return hit.position;
        }
        else
        {
            return transform.position;
        }

    }

    // 상태 변화 함수(정지, 공격, 정찰)
    public void TigerStateChanger()
    {
        int level = GameMgr.Instance.PlayerInit().GetBoundaryLevel();
        //Debug.Log("BoundaryLevel = " + level);
        switch (level)
        {
            case 0:
                tigerState = TState.Idle;
                break;
            case 1:
                tigerState = TState.Idle;
                break;
            case 2:
                tigerState = TState.Run;
                break;
            case 3:
                tigerState = TState.Attack;
                break;
            case 4:
                tigerState = TState.RunBack;
                break;

        }
        //GetRandomMove();
    }
    // 움직임 함수
    private void TigerMove()
    {
        // 걷기 애니메이션 재생

        //걷기 코드
        //float speed = tigerWalkSpeed * Time.deltaTime;
        //transform.Translate(Vector3.forward * speed);

        meshAgent.speed = tigerWalkSpeed;
        animator.SetBool("ScanTigerL", false);
        animator.SetBool("ScanTigerS", true);

    }
    private void TigerRun()
    {

        //뛰기 코드
        //float speed = tigerRunSpeed * Time.deltaTime;
        //transform.Translate(Vector3.forward * speed);
        meshAgent.isStopped = false;
        meshAgent.SetDestination(playerT.position);
        meshAgent.speed = tigerRunSpeed;
        animator.SetBool("ScanTigerS", false);
        animator.SetBool("ScanTigerL", true);

    }

    private void TigerAttack()
    {
        meshAgent.velocity = Vector3.zero;
        animator.SetBool("ScanTigerS", false);
        animator.SetBool("AttackTiger", true);
    }
}

using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Tiger : MonoBehaviour
{
    // 필요 변수 (호랑이 속도, 움직임 상태, 
    private Vector3 spawnPos;

    [Header("TigerStateInfo")]
    public float tigerWalkSpeed;
    public float tigerRunSpeed;
    public float tigerAttackSpeed;
    public TState tigerState;

    private Animator animator;
    [SerializeField] private AnimatorController changeAni;

    private NavMeshAgent meshAgent;

    public Transform playerT;

    // 호랑이 자동 움직임 변수
    private float updateInterval = 10f;
    private float timeSinceLastUpdate;

    // 범위 스캔 체크 변수
    public float runTime = 5f;
    private float checkRunTime;

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
        // 첫 등장은 마을에서 집에서 나온 뒤.(배치 해두고 스토리 이후 시작)
        playerT = transform;
        tigerState = TState.Idle;
        animator = GetComponent<Animator>();
        meshAgent = GetComponent<NavMeshAgent>();
        timeSinceLastUpdate = updateInterval;
    }

    // Update is called once per frame
    void Update()
    {

        // 플레이어 좌표를 향해 일정 속도로 달려오기. -> 플레이어와 일정범위 안으로 가까워지면 점프 공격
        // 곶감에 당했을 때 (도망)

        // 떡을 받았을 때 (심취)
        TigerStateChanger();
        switch (tigerState)
        {
            case TState.Idle:
                //Debug.Log("Idle");
                GetRandomMove();
                TigerWalk();
                break;
            case TState.Run:
                //Debug.Log("Run");
                GetRandomMove();
                TigerRun();
                break;
            case TState.Attack:
                //Debug.Log("Attack");
                //ScanPlayer();
                TigerAttack();
                break;
            case TState.Eat:
                TigerEat();
                break;
            case TState.RunBack:
                TigerRunBack();
                break;
        }
        // 이동 테스트

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "gotgam")
        {
            Debug.Log("곶감에 맞았다!");
            SoundManager.Instance.Play("SadTiger");
            gameObject.GetComponent<Animator>().runtimeAnimatorController = changeAni;
            tigerState = TState.RunBack;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "dduk")
        {
            Debug.Log("떡이다!");
        }
    }


    //public void OnCheckScanRange()
    //{
    //    var player = GameMgr.Instance.PlayerInit();
    //    if (updateCheckRange != checkRange)
    //    {
    //        switch (checkRange)
    //        {
    //            case 0:
    //                break;
    //            case 1:
    //                player.SetUpBoundaryLevel();
    //                break;
    //            case 2:
    //                player.SetDownBoundaryLevel();
    //                break;
    //        }

    //        //Debug.Log("CheckRange : " + checkRange);
    //        updateCheckRange = checkRange;
    //    }


    //}

    // 3초마다 새로운 랜덤 위치를 찾아 이동하는 함수
    public void GetRandomMove()
    {
        timeSinceLastUpdate += Time.deltaTime;
        // OnCheckScanRange();
        if (timeSinceLastUpdate >= updateInterval)
        {
            if (VRPlayer.instance.nowState == VRPlayer.PlayerState.HIDE)
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
    //public void TigerStateChanger()
    //{
    //    Debug.Log("상태변화");
    //    int level = GameMgr.Instance.PlayerInit().GetBoundaryLevel();
    //    //Debug.Log("BoundaryLevel = " + level);
    //    switch (level)
    //    {
    //        case 0:
    //            tigerState = TState.Idle;
    //            break;
    //        case 1:
    //            tigerState = TState.Idle;
    //            break;
    //        case 2:
    //            tigerState = TState.Run;
    //            break;
    //        case 3:
    //            tigerState = TState.Attack;
    //            break;
    //        case 4:
    //            tigerState = TState.RunBack;
    //            break;

    //    }
    //    GetRandomMove();
    //}
    public void TigerStateChanger()
    {
        if (VRPlayer.instance.nowState != VRPlayer.instance.changeState)
            //Debug.Log("BoundaryLevel = " + level);
            switch (VRPlayer.instance.nowState)
            {
                case VRPlayer.PlayerState.WALK:
                    tigerState = TState.Idle;
                    break;
                case VRPlayer.PlayerState.RUN:
                    tigerState = TState.Run;
                    break;
                case VRPlayer.PlayerState.JUMP:
                    tigerState = TState.Run;
                    break;
                case VRPlayer.PlayerState.HIDE:
                    tigerState = TState.Idle;
                    break;
            }
        VRPlayer.instance.nowState = VRPlayer.instance.changeState;
    }
    // 움직임 함수
    private void TigerWalk()
    {
        // 걷기 애니메이션 재생

        //걷기 코드
        //float speed = tigerWalkSpeed * Time.deltaTime;
        //transform.Translate(Vector3.forward * speed);
        if (VRPlayer.instance.transform == null) 
            Debug.Log("없나?");
        playerT = VRPlayer.instance.transform;
        meshAgent.speed = tigerWalkSpeed;
        animator.SetBool("IsWalk", true);
        animator.SetBool("IsRun", false);
        animator.SetBool("AttackTiger", false);
        animator.SetBool("IsEating", false);
        animator.SetBool("IsRunBack", false);

    }
    private void TigerRun()
    {

        //뛰기 코드
        //float speed = tigerRunSpeed * Time.deltaTime;
        //transform.Translate(Vector3.forward * speed);
        meshAgent.speed = tigerRunSpeed;
        animator.SetBool("IsRun", true);
        animator.SetBool("IsWalk", false);
        animator.SetBool("AttackTiger", false);
        animator.SetBool("IsEating", false);
        animator.SetBool("IsRunBack", false);

    }

    private void TigerAttack()
    {
        meshAgent.velocity = Vector3.zero;
        animator.SetBool("AttackTiger", true);
        animator.SetBool("IsWalk", false);
        animator.SetBool("IsRun", false);
        animator.SetBool("IsEating", false);
        animator.SetBool("IsRunBack", false);
    }

    private void TigerEat()
    {
        meshAgent.velocity = Vector3.zero;
        animator.SetBool("IsEating", true);
        animator.SetBool("IsWalk", false);
        animator.SetBool("IsRun", false);
        animator.SetBool("AttackTiger", false);
        animator.SetBool("IsRunBack", false);
    }

    private void TigerRunBack()
    {
        animator.SetBool("IsRunBack", true);
        animator.SetBool("IsWalk", false);
        animator.SetBool("IsRun", false);
        animator.SetBool("AttackTiger", false);
        animator.SetBool("IsEating", false);
        TigerTurnBack();
    }

    private void TigerTurnBack()
    {
        checkRunTime += Time.deltaTime;
        if(checkRunTime >= runTime)
        {
            checkRunTime = 0;
            animator.SetBool("IsWalk", true);
        }
        else if(checkRunTime < runTime)
        {
            meshAgent.speed = tigerRunSpeed;
            meshAgent.SetDestination(-playerT.position);
        }
        animator.SetBool("IsTurnBack", true);
    }

    // 플레이어 감지 함수(사용 안함)
    private void ScanPlayer()
    {
        // 충돌 판정 -> 태그 플레이어
        // if((transform.position)
        // 플레이어 방향 바라보기

        // 위치 이동
        //vector3 dir = playert.position - transform.position;
        //dir.y = 0f;
        //quaternion rot = quaternion.lookrotation(dir.normalized);
        //transform.rotation = rot;

        // navMesh 사용 이동
        meshAgent.SetDestination(playerT.position);

        // 플레이어에게 달려가기 방향만 바라보고 애니메이션으로 달리기.

        //transform.position = Vector3.MoveTowards(transform.position, playerT.position, tigerAttackSpeed * Time.deltaTime);
    }

}

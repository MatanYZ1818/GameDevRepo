using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.AI;

public class BradyBehavior : MonoBehaviour
{
    Animator animator;
    NavMeshAgent NMAgent;
    LineRenderer path;
    public GameObject target_1;
    public GameObject target_2;
    public GameObject target_3;
    public GameObject target_behind_bar;
    bool isTarget1 = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        NMAgent = GetComponent<NavMeshAgent>();
        path = GetComponent<LineRenderer>();
        path.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        path.positionCount = NMAgent.path.corners.Length;
        path.SetPositions(NMAgent.path.corners);
        if (!NMAgent.isStopped)
        {
            float distance;
            if(isTarget1)
                 distance = Vector3.Distance(transform.position, target_1.transform.position);
            else
                distance = Vector3.Distance(transform.position, target_behind_bar.transform.position);

            if (distance <2 ) {
                if (isTarget1){
                    NMAgent.SetDestination(target_behind_bar.transform.position);
                    isTarget1 = false;
                }
                else{
                    NMAgent.SetDestination(target_1.transform.position);
                    isTarget1 = true;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            animator.SetInteger("State", 1);
            //Starts computing the path
            NMAgent.SetDestination(target_1.transform.position);
            //create line renderer
            path.positionCount = NMAgent.path.corners.Length;
            path.SetPositions(NMAgent.path.corners);

        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            animator.SetInteger("State", 0);
        }
    }
}

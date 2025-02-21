using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))] // Fixed typo in attribute name
public class AITarget : MonoBehaviour
{
    public Transform Target;
    public float AttackDistance;
    public float RunDistance;

    private NavMeshAgent m_Agent;
    private Animator m_Animator;
    private float m_Distance;

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
    }

     public void NewEvent()
    {
        Debug.Log("NewEvent triggered!"); // Test with a log
    }

    public void PlayStep()
    {
        Debug.Log("PlayStep triggered!"); // Test with a log
    }

    public void StartAttack()
    {
        Debug.Log("StartAttack triggered!"); // Test with a log
    }

    public void EndAttack()
    {
        Debug.Log("EndAttack triggered!"); // Test with a log
    }



    void Update()
    {
        m_Distance = Vector3.Distance(m_Agent.transform.position, Target.position); // Fixed method name and property
        if (m_Distance < AttackDistance)
        {
            m_Agent.isStopped = true;
            m_Animator.SetBool("Attack", true);
        }
        else
        {
            m_Agent.isStopped = false;
            m_Animator.SetBool("Attack", false);
            m_Agent.destination = Target.position;
        }

        

    }

    void OnAnimatorMove()
    {
        if (!m_Animator.GetBool("Attack")) // Simplified boolean check
        {
            m_Agent.speed = (m_Animator.deltaPosition / Time.deltaTime).magnitude;
        }
    }
}
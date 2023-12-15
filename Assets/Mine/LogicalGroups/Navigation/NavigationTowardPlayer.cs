using UnityEngine;
using UnityEngine.AI;

namespace Unity.AI.Navigation.Samples
{
    /// <summary>
    /// Use physics raycast hit from mouse click to set agent destination 
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavigationLoopTowardPlayer : MonoBehaviour
    {
        NavMeshAgent m_Agent;
        public Transform[] goals = new Transform[1];
        private int m_NextGoal = 0;
    
        void Start()
        {
            m_Agent = GetComponent<NavMeshAgent>();
            // if (goals.Length == 0)
            // {
            //     Debug.LogError("Please assign all 3 goals in the inspector");
            // }
        }
    
        void Update()
        {
            if (goals[0] == null)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    goals[0] = player.transform;
                }
            }

            if (goals.Length == 0)
                return;

            float distance = Vector3.Distance(m_Agent.transform.position, goals[m_NextGoal].position);
            // if (distance < 0.5f)
            // {
            //     m_NextGoal = m_NextGoal != 2 ? m_NextGoal + 1 : 0;
            // }
            m_Agent.destination = goals[m_NextGoal].position;
        }
    }
}
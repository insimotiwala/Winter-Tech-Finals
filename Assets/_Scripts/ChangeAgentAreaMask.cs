using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChangeAgentAreaMask : MonoBehaviour
{
    private const string _agentTag = "Agent";//agent tag
    private const string _agentName = "AGENT";
    private bool _originalArea = true;

    private const string _areaStreet = "STREET";

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            GameObject[] agents = GameObject.FindGameObjectsWithTag(_agentTag);

            //update each agent
            foreach (GameObject agent in agents)
            {
                if (agent.name != _agentName) { continue; } //if agent name is wrong, skip
                NavMeshAgent nma = agent.GetComponent<NavMeshAgent>();
                if (nma == null) { continue; } //if NavMeshAgent component doesn't exist skip
                int areaMask = nma.areaMask;

                //update area mask
                if (_originalArea)
                {
                    //if we want to update areas
                    areaMask += 1 << NavMesh.GetAreaFromName(_areaStreet);
                }
                else
                {
                    //if we want to revert areas
                    areaMask -= 1 << NavMesh.GetAreaFromName(_areaStreet);
                }
                nma.areaMask = areaMask;
                nma.ResetPath(); //changing areaMask makes the path stale, so we have to reset (keeps same target)
            }

            //toggel original area status
            _originalArea = !_originalArea;
        }
    }
}
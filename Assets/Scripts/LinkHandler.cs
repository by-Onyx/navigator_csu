using UnityEngine;
using UnityEngine.AI;

public class NavMeshLinkHandler : MonoBehaviour
{
    private NavMeshAgent navAgent;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.autoTraverseOffMeshLink = false;
    }

    private void Update()
    {
        // ���������, ��������� �� agnet �� OffMeshLink
        if (navAgent.isOnOffMeshLink)
        {
            // ���������, ������ �� agent OffMeshLink
            if (navAgent.currentOffMeshLinkData.linkType == OffMeshLinkType.LinkTypeManual)
            {
                // ��������� �������� ��� ����������� ����� OffMeshLink
                //Debug.Log("Agent traversed manual OffMeshLink");
                print("������ ����");

                // �������� OffMeshLink ��� ���������
                navAgent.CompleteOffMeshLink();
            }
        }
    }
}
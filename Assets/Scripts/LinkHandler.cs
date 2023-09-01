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
        // Проверяем, находится ли agnet на OffMeshLink
        if (navAgent.isOnOffMeshLink)
        {
            // Проверяем, прошел ли agent OffMeshLink
            if (navAgent.currentOffMeshLinkData.linkType == OffMeshLinkType.LinkTypeManual)
            {
                // Выполняем действия при прохождении через OffMeshLink
                //Debug.Log("Agent traversed manual OffMeshLink");
                print("прошли линк");

                // Помечаем OffMeshLink как прошедший
                navAgent.CompleteOffMeshLink();
            }
        }
    }
}
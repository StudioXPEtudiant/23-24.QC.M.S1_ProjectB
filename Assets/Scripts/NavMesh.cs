using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class NavMesh : MonoBehaviour
{
    private NavMeshSurface _navMeshSurface;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!GetComponent<NavMeshSurface>())
        {
            gameObject.AddComponent<NavMeshSurface>();
        }
        
        _navMeshSurface = GetComponent<NavMeshSurface>();
        
        _navMeshSurface.RemoveData();
        _navMeshSurface.BuildNavMesh();
    }
}

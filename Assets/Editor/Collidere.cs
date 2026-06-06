using UnityEngine;
using UnityEditor;

public class AddCollidersToChildren : EditorWindow
{
    [MenuItem("Tools/Add MeshColliders to Selected Children")]
    static void AddColliders()
    {
        int totalAdded = 0;
        foreach (GameObject obj in Selection.gameObjects)
        {
            MeshFilter[] filters = obj.GetComponentsInChildren<MeshFilter>();
            foreach (MeshFilter mf in filters)
            {
                if (mf.GetComponent<MeshCollider>() == null)
                {
                    MeshCollider mc = mf.gameObject.AddComponent<MeshCollider>();
                    mc.convex = false;
                    totalAdded++;
                }
            }
        }
        Debug.Log($"Added {totalAdded} Mesh Colliders!");
    }
}
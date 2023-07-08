using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Willow.Library;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class FeelingEdgy : MonoBehaviour
{
    [Min(0)]
    public int subdivisions;
    public float surfaceDistance;

#if UNITY_EDITOR

    [MenuItem("GameObject/GET FUCKING EDGY", priority = -1000)]
    public static void MakeLine()
    {

        MeshFilter filter = Selection.activeGameObject?.GetComponent<MeshFilter>();
        if (filter == null) return;

        Mesh mesh = filter.sharedMesh;
        if (mesh == null) return;

        var newGO = new GameObject("Edgy Line", typeof(FeelingEdgy), typeof(MeshFilter), typeof(LineRenderer));
        newGO.transform.parent = Selection.activeGameObject.transform;
        newGO.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        newGO.transform.localScale = Vector3.one;
        newGO.GetComponent<MeshFilter>().sharedMesh = mesh;
        LineRenderer line = newGO.GetComponent<LineRenderer>();
        line.positionCount = 0;
        line.useWorldSpace = false;
        line.widthMultiplier = 0.1f;
        Selection.activeGameObject = newGO;
    }

    [CustomEditor(typeof(FeelingEdgy))]
    public class Inspector : Editor
    {
        new FeelingEdgy target;
        MeshFilter filter;
        Mesh mesh;
        LineRenderer line;

        private bool editing = false;
        private bool valid = false;
        private Color color;
        
        private void OnEnable()
        {
            target = base.target as FeelingEdgy;
            target.Populate(ref filter);
            target.Populate(ref line);
            mesh = filter.sharedMesh;

            color = Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.8f, 1f);

            if (target == null) return;
            if (filter == null) return;
            if (line == null) return;
            if (mesh == null) return;

            valid = true;
        }

        public override void OnInspectorGUI()
        {
            GUI.color = color;
            base.OnInspectorGUI();

            GUI.enabled = valid;
            if (!editing)
            {
                if (GUILayout.Button("Re-write"))
                {
                    editing = true;
                    line.positionCount = 0;
                }
            }
            else
            {
                if (GUILayout.Button("Done"))
                {
                    editing = false;
                }
            }
        }

        private void OnSceneGUI()
        {
            Handles.color = color;
            Handles.matrix = target.transform.localToWorldMatrix;

            for (int i = 1; i < line.positionCount; i++)
            {
                Handles.DrawLine(line.GetPosition(i - 1), line.GetPosition(i));
            }

            if (editing)
            {
                for (int v = 0; v < mesh.vertices.Length; v++)
                {
                    Vector3 vert = mesh.vertices[v];
                    Vector3 normal = mesh.normals[v];
                    if (Handles.Button(vert, Quaternion.identity, 0.001f, 0.001f, Handles.CubeHandleCap))
                    {
                        if (target.subdivisions == 0 || line.positionCount == 0)
                        {
                            int i = line.positionCount++;
                            line.SetPosition(i, vert + normal * target.surfaceDistance); 
                        }
                        else
                        {
                            Vector3 start = line.GetPosition(line.positionCount - 1);
                            Vector3 end = vert + normal * target.surfaceDistance;
                            float f = 0f;
                            while (f < 1f)
                            {
                                f += 1f / (1 + target.subdivisions);
                                int i = line.positionCount++;
                                line.SetPosition(i, Vector3.Lerp(start, end, f));
                            }
                        }
                    }
                }
            }

        }
    }
#endif
}

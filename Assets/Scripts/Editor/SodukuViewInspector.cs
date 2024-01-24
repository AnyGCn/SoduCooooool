using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SodukuView))]
public class SodukuViewInspector : Editor
{
    public void JumpToElementButton(int x, int y)
    {
        if (GUILayout.Button($"{(char)('A' + x)}{y}",
                new GUILayoutOption[] { GUILayout.Width(32), GUILayout.Height(32) }))
        {
            Selection.activeGameObject =  ((SodukuView) target).elements[x * 9 + y].gameObject;
        }
    }
    
    public override void OnInspectorGUI()
    {
        SodukuView view = (SodukuView) target;
        view.elementPrefab = EditorGUILayout.ObjectField(view.elementPrefab, typeof(GameObject), true) as GameObject;
        for (int i = 0; i < 9; ++i)
        {
            if (i % 3 == 0)
            {
                EditorGUILayout.Space();
            }
            
            using EditorGUILayout.HorizontalScope horizontalScope = new EditorGUILayout.HorizontalScope();
            GUILayout.FlexibleSpace();
            for (int j = 0; j < 9; ++j)
            {
                if (j % 3 == 0)
                {
                    EditorGUILayout.Space();
                }
                
                JumpToElementButton(i, j);
            }
            
            GUILayout.FlexibleSpace();
        }
        
        EditorGUILayout.Space();
        if (GUILayout.Button("Create Grid"))
        {
            CreateGrid(view);
        }
    }

    private void CreateGrid(SodukuView view)
    {
        if (view.elementPrefab == null)
        {
            Debug.LogError("Element Prefab is null");
            return;
        }
        
        Undo.RecordObject(view, "Create Grid");
        for (int i = 0; i < view.elements.Length; i++)
        {
            GameObject element = PrefabUtility.InstantiatePrefab(view.elementPrefab) as GameObject;
            element.transform.SetParent(view.transform);
            element.transform.localScale = Vector3.one;
            element.transform.localPosition = Vector3.zero;
            element.name = $"Element[{i / 9},{i % 9}]";
            view.elements[i] = element.GetComponent<SodukuElement>();
            Undo.RegisterCreatedObjectUndo(element, "Create Grid");
        }
    }
}

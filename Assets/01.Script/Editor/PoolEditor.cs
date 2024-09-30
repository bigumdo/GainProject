using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class PoolEditor : EditorWindow
{
    private readonly string path = "Assets/08.SO/Pool";//생성할 경로
    private PoolSO poolSOs;
    private Editor _editor; //띄워주는 인스펙터
    private static int cnt;

    [MenuItem("Editor/UtilManager")] //
    private static void OpenWindow()
    {
        PoolEditor window = GetWindow<PoolEditor>("PoolManager");
        window.minSize = new Vector2(700, 500);
        window.Show();
    }

    private void OnGUI()
    {
        CreateSO();
        PoolSOInput();
        ShowInspector();
    }

    private void CreateSO()
    {
        if (GUILayout.Button("Create SO"))
        {
            PoolSO poolSO = CreateInstance<PoolSO>();
            string realPath = AssetDatabase.GenerateUniqueAssetPath($"{path}/pool{cnt}.asset");
            cnt++;
            AssetDatabase.CreateAsset( poolSO, realPath );
        }
    }

    private void ShowInspector()
    {
        if (poolSOs == null) return;
        Editor.CreateCachedEditor(poolSOs, null, ref _editor);
        _editor.OnInspectorGUI();
    }

    private void PoolSOInput()
    {
        poolSOs = (PoolSO)EditorGUILayout.ObjectField(poolSOs, typeof(PoolSO), false);
    }


}

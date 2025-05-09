using UnityEditor;
using UnityEngine;

public class URPMaterialConverter : EditorWindow
{
    [MenuItem("Tools/Convert Materials to URP")]
    public static void ConvertAllMaterials()
    {
        string[] guids = AssetDatabase.FindAssets("t:Material");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);
            if (mat.shader.name.Contains("Standard"))
            {
                mat.shader = Shader.Find("Universal Render Pipeline/Lit");
                Debug.Log($"Converted: {mat.name}");
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TerrainFullMirrorWithObjects : MonoBehaviour
{
    [MenuItem("Tools/Terrain/Mirror Full Terrain + Objects (Point Symmetry)")]
    static void MirrorTerrainPointSymmetric()
    {
        Terrain sourceTerrain = Selection.activeGameObject?.GetComponent<Terrain>();
        if (sourceTerrain == null)
        {
            Debug.LogError("선택된 오브젝트에 Terrain 컴포넌트가 없습니다.");
            return;
        }

        TerrainData sourceData = sourceTerrain.terrainData;
        Vector3 terrainPos = sourceTerrain.transform.position;
        Vector3 terrainSize = sourceData.size;
        Vector3 terrainCenter = terrainPos + terrainSize * 0.5f;

        // 1️. HeightMap 반전
        int width = sourceData.heightmapResolution;
        int height = sourceData.heightmapResolution;
        float[,] srcHeights = sourceData.GetHeights(0, 0, width, height);
        float[,] dstHeights = new float[width, height];

        for (int x = 0; x < width; x++)
            for (int z = 0; z < height; z++)
                dstHeights[x, z] = srcHeights[width - x - 1, height - z - 1];

        // 2️. TerrainData 생성
        TerrainData newData = new TerrainData
        {
            heightmapResolution = width,
            size = terrainSize,
            baseMapResolution = sourceData.baseMapResolution,
            alphamapResolution = sourceData.alphamapResolution,
        };
        newData.SetDetailResolution(sourceData.detailResolution, 8);
        newData.SetHeights(0, 0, dstHeights);
        newData.terrainLayers = sourceData.terrainLayers;

        // 3️. Texture Layer 복사 (Splatmap)
        int aw = newData.alphamapWidth;
        int ah = newData.alphamapHeight;
        int al = sourceData.alphamapLayers;
        float[,,] srcAlpha = sourceData.GetAlphamaps(0, 0, aw, ah);
        float[,,] dstAlpha = new float[aw, ah, al];

        for (int x = 0; x < aw; x++)
            for (int z = 0; z < ah; z++)
                for (int l = 0; l < al; l++)
                    dstAlpha[x, z, l] = srcAlpha[aw - x - 1, ah - z - 1, l];

        newData.SetAlphamaps(0, 0, dstAlpha);

        // 4️. Detail 복사
        newData.detailPrototypes = sourceData.detailPrototypes;
        int layers = newData.detailPrototypes.Length;
        int dr = newData.detailResolution;

        for (int l = 0; l < layers; l++)
        {
            int[,] srcDetail = sourceData.GetDetailLayer(0, 0, dr, dr, l);
            int[,] dstDetail = new int[dr, dr];
            for (int x = 0; x < dr; x++)
                for (int z = 0; z < dr; z++)
                    dstDetail[x, z] = srcDetail[dr - x - 1, dr - z - 1];
            newData.SetDetailLayer(0, 0, l, dstDetail);
        }

        // 5️. Tree 복사
        newData.treePrototypes = sourceData.treePrototypes;
        TreeInstance[] srcTrees = sourceData.treeInstances;
        TreeInstance[] dstTrees = new TreeInstance[srcTrees.Length];

        for (int i = 0; i < srcTrees.Length; i++)
        {
            TreeInstance t = srcTrees[i];
            t.position = new Vector3(1f - t.position.x, t.position.y, 1f - t.position.z);
            dstTrees[i] = t;
        }

        newData.treeInstances = dstTrees;

        // 6️. 새 Terrain 생성
        Vector3 mirrorOffset = terrainPos + new Vector3(terrainSize.x, 0f, terrainSize.z);
        GameObject newTerrain = Terrain.CreateTerrainGameObject(newData);
        newTerrain.transform.position = mirrorOffset;
        newTerrain.name = "MirroredTerrain_180";

        // 7️. Terrain 위의 오브젝트 복사
        Bounds terrainBounds = new Bounds(terrainCenter, terrainSize);
        GameObject[] all = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in all)
        {
            if (obj == sourceTerrain.gameObject || obj.GetComponent<Terrain>())
                continue;

            Vector3 pos = obj.transform.position;
            if (!terrainBounds.Contains(pos))
                continue;

            Vector3 mirroredLocal = pos - terrainCenter;
            mirroredLocal.x *= -1;
            mirroredLocal.z *= -1;
            Vector3 mirroredPos = mirrorOffset + (terrainCenter + mirroredLocal) - terrainPos;

            GameObject copy = Instantiate(obj, mirroredPos, obj.transform.rotation * Quaternion.Euler(0, 180f, 0));
            copy.name = obj.name + "_Mirrored";
            Undo.RegisterCreatedObjectUndo(copy, "Mirror Object");
        }

        Debug.Log("Terrain 및 오브젝트 반전 완료!");
    }

    [MenuItem("Tools/Terrain/Mirror Full Terrain + Objects (X Axis)")]
    static void MirrorTerrainX()
    {
        Terrain sourceTerrain = Selection.activeGameObject?.GetComponent<Terrain>();
        if (sourceTerrain == null)
        {
            Debug.LogError("선택된 오브젝트에 Terrain 컴포넌트가 없습니다.");
            return;
        }

        TerrainData sourceData = sourceTerrain.terrainData;
        Vector3 terrainPos = sourceTerrain.transform.position;
        Vector3 terrainSize = sourceData.size;
        Vector3 terrainCenter = terrainPos + terrainSize * 0.5f;

        // 1️. HeightMap 반전
        int width = sourceData.heightmapResolution;
        int height = sourceData.heightmapResolution;
        float[,] srcHeights = sourceData.GetHeights(0, 0, width, height);
        float[,] dstHeights = new float[width, height];

        for (int x = 0; x < width; x++)
            for (int z = 0; z < height; z++)
                dstHeights[x, z] = srcHeights[width - x - 1, z];

        // 2️. TerrainData 생성
        TerrainData newData = new TerrainData
        {
            heightmapResolution = width,
            size = terrainSize,
            baseMapResolution = sourceData.baseMapResolution,
            alphamapResolution = sourceData.alphamapResolution,
        };
        newData.SetDetailResolution(sourceData.detailResolution, 8);
        newData.SetHeights(0, 0, dstHeights);
        newData.terrainLayers = sourceData.terrainLayers;

        // 3️. Texture Layer 복사 (Splatmap)
        int aw = newData.alphamapWidth;
        int ah = newData.alphamapHeight;
        int al = sourceData.alphamapLayers;
        float[,,] srcAlpha = sourceData.GetAlphamaps(0, 0, aw, ah);
        float[,,] dstAlpha = new float[aw, ah, al];

        for (int x = 0; x < aw; x++)
            for (int z = 0; z < ah; z++)
                for (int l = 0; l < al; l++)
                    dstAlpha[x, z, l] = srcAlpha[aw - x - 1, z, l];

        newData.SetAlphamaps(0, 0, dstAlpha);

        // 4️. Detail 복사
        newData.detailPrototypes = sourceData.detailPrototypes;
        int layers = newData.detailPrototypes.Length;
        int dr = newData.detailResolution;

        for (int l = 0; l < layers; l++)
        {
            int[,] srcDetail = sourceData.GetDetailLayer(0, 0, dr, dr, l);
            int[,] dstDetail = new int[dr, dr];
            for (int x = 0; x < dr; x++)
                for (int z = 0; z < dr; z++)
                    dstDetail[x, z] = srcDetail[dr - x - 1, z];
            newData.SetDetailLayer(0, 0, l, dstDetail);
        }

        // 5️. Tree 복사
        newData.treePrototypes = sourceData.treePrototypes;
        TreeInstance[] srcTrees = sourceData.treeInstances;
        TreeInstance[] dstTrees = new TreeInstance[srcTrees.Length];

        for (int i = 0; i < srcTrees.Length; i++)
        {
            TreeInstance t = srcTrees[i];
            t.position = new Vector3(1f - t.position.x, t.position.y, t.position.z);
            dstTrees[i] = t;
        }

        newData.treeInstances = dstTrees;

        // 6️. 새 Terrain 생성
        Vector3 mirrorOffset = terrainPos + new Vector3(terrainSize.x, 0f, 0f);
        GameObject newTerrain = Terrain.CreateTerrainGameObject(newData);
        newTerrain.transform.position = mirrorOffset;
        newTerrain.name = "MirroredTerrain_X_Axis";

        // 7️. Terrain 위의 오브젝트 복사
        Bounds terrainBounds = new Bounds(terrainCenter, terrainSize);
        GameObject[] all = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in all)
        {
            if (obj == sourceTerrain.gameObject || obj.GetComponent<Terrain>())
                continue;

            Vector3 pos = obj.transform.position;
            if (!terrainBounds.Contains(pos))
                continue;

            Vector3 mirroredLocal = pos - terrainCenter;
            mirroredLocal.x *= -1;
            Vector3 mirroredPos = mirrorOffset + (terrainCenter + mirroredLocal) - terrainPos;

            GameObject copy = Instantiate(obj, mirroredPos, obj.transform.rotation * Quaternion.Euler(0, 270f, 0));
            copy.name = obj.name + "_Mirrored_X_Axis";
            Undo.RegisterCreatedObjectUndo(copy, "Mirror Object");
        }

        Debug.Log("Terrain 및 오브젝트 반전 완료!");
    }

    [MenuItem("Tools/Terrain/Mirror Full Terrain + Objects (Z Axis)")]
    static void MirrorTerrainZ()
    {
        Terrain sourceTerrain = Selection.activeGameObject?.GetComponent<Terrain>();
        if (sourceTerrain == null)
        {
            Debug.LogError("선택된 오브젝트에 Terrain 컴포넌트가 없습니다.");
            return;
        }

        TerrainData sourceData = sourceTerrain.terrainData;
        Vector3 terrainPos = sourceTerrain.transform.position;
        Vector3 terrainSize = sourceData.size;
        Vector3 terrainCenter = terrainPos + terrainSize * 0.5f;

        // 1️. HeightMap 반전
        int width = sourceData.heightmapResolution;
        int height = sourceData.heightmapResolution;
        float[,] srcHeights = sourceData.GetHeights(0, 0, width, height);
        float[,] dstHeights = new float[width, height];

        for (int x = 0; x < width; x++)
            for (int z = 0; z < height; z++)
                dstHeights[x, z] = srcHeights[x, height - z - 1];

        // 2️. TerrainData 생성
        TerrainData newData = new TerrainData
        {
            heightmapResolution = width,
            size = terrainSize,
            baseMapResolution = sourceData.baseMapResolution,
            alphamapResolution = sourceData.alphamapResolution,
        };
        newData.SetDetailResolution(sourceData.detailResolution, 8);
        newData.SetHeights(0, 0, dstHeights);
        newData.terrainLayers = sourceData.terrainLayers;

        // 3️. Texture Layer 복사 (Splatmap)
        int aw = newData.alphamapWidth;
        int ah = newData.alphamapHeight;
        int al = sourceData.alphamapLayers;
        float[,,] srcAlpha = sourceData.GetAlphamaps(0, 0, aw, ah);
        float[,,] dstAlpha = new float[aw, ah, al];

        for (int x = 0; x < aw; x++)
            for (int z = 0; z < ah; z++)
                for (int l = 0; l < al; l++)
                    dstAlpha[x, z, l] = srcAlpha[x, ah - z - 1, l];

        newData.SetAlphamaps(0, 0, dstAlpha);

        // 4️. Detail 복사
        newData.detailPrototypes = sourceData.detailPrototypes;
        int layers = newData.detailPrototypes.Length;
        int dr = newData.detailResolution;

        for (int l = 0; l < layers; l++)
        {
            int[,] srcDetail = sourceData.GetDetailLayer(0, 0, dr, dr, l);
            int[,] dstDetail = new int[dr, dr];
            for (int x = 0; x < dr; x++)
                for (int z = 0; z < dr; z++)
                    dstDetail[x, z] = srcDetail[x, dr - z - 1];
            newData.SetDetailLayer(0, 0, l, dstDetail);
        }

        // 5️. Tree 복사
        newData.treePrototypes = sourceData.treePrototypes;
        TreeInstance[] srcTrees = sourceData.treeInstances;
        TreeInstance[] dstTrees = new TreeInstance[srcTrees.Length];

        for (int i = 0; i < srcTrees.Length; i++)
        {
            TreeInstance t = srcTrees[i];
            t.position = new Vector3(t.position.x, t.position.y, 1f - t.position.z);
            dstTrees[i] = t;
        }

        newData.treeInstances = dstTrees;

        // 6️. 새 Terrain 생성
        Vector3 mirrorOffset = terrainPos + new Vector3(0f, 0f, terrainSize.z);
        GameObject newTerrain = Terrain.CreateTerrainGameObject(newData);
        newTerrain.transform.position = mirrorOffset;
        newTerrain.name = "MirroredTerrain_Z_Axis";

        // 7️. Terrain 위의 오브젝트 복사
        Bounds terrainBounds = new Bounds(terrainCenter, terrainSize);
        GameObject[] all = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in all)
        {
            if (obj == sourceTerrain.gameObject || obj.GetComponent<Terrain>())
                continue;

            Vector3 pos = obj.transform.position;
            if (!terrainBounds.Contains(pos))
                continue;

            Vector3 mirroredLocal = pos - terrainCenter;
            mirroredLocal.z *= -1;
            Vector3 mirroredPos = mirrorOffset + (terrainCenter + mirroredLocal) - terrainPos;

            GameObject copy = Instantiate(obj, mirroredPos, obj.transform.rotation * Quaternion.Euler(0, 90f, 0));
            copy.name = obj.name + "_Mirrored_Z_Axis";
            Undo.RegisterCreatedObjectUndo(copy, "Mirror Object");
        }

        Debug.Log("Terrain 및 오브젝트 반전 완료!");
    }
}

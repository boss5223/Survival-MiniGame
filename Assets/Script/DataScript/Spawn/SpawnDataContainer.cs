using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDataContainer: Singleton<SpawnDataContainer>
{
    private List<RawSpawnerData> spawnerData;

    //public void Start()
    //{
    //    string json = Resources.Load<TextAsset>("Data/SpawnerSize").text;
    //    spawnerData = JsonConvert.DeserializeObject<List<RawSpawnerData>>(json);
    //    Debug.Log(json);
    //}
    public SpawnDataContainer()
    {
        string json = Resources.Load<TextAsset>("Data/SpawnerSize").text;
        spawnerData = JsonConvert.DeserializeObject<List<RawSpawnerData>>(json);
        Debug.Log(json);
    }
    public void SetData(List<RawSpawnerData> data) => spawnerData = data;

    public List<RawSpawnerData> GetSpawnerDatas()
    {
        return new List<RawSpawnerData>(spawnerData);
    }

    //public RawSpawnerData GetSpawnerById(int id)
    //{
    //    return spawnerData.Find(spawnerDatas => spawnerDatas.spawnerid == id);
    //}

}



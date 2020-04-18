using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;


public class MonsterDataContainer: Singleton<MonsterDataContainer>
{
    private List<RawMonsterData> monstersData;
    public MonsterDataContainer()
    {
        string json = Resources.Load<TextAsset>("Data/MonsterStat").text;
        monstersData = JsonConvert.DeserializeObject<List<RawMonsterData>>(json);
        Debug.Log(json);
    }

    public void SetData(List<RawMonsterData> data) => monstersData = data;

    public List<RawMonsterData> GetMonstersData()
    {
        return new List<RawMonsterData>(monstersData);
    }
}

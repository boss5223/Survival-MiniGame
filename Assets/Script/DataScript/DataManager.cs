using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class DataManager
{
    public const string monsterDatafile = "/monsterFile.fun";
    public const string spawnDatafile = "/spawnerFile.fun";
    
    //public static  void SaveDataMonster (MonsterAttribute monster)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    string path = "E:/Survival Game/Survival MINI Game/Assets/Data" + monsterDatafile;
    //    FileStream stream = new FileStream(path, FileMode.Create);

    //    MonsterDataContainer monsdata = new MonsterDataContainer(monster);

    //    formatter.Serialize(stream, monsdata);
    //    Debug.Log("File has Create!");
    //    stream.Close();
    //}
    
    //public static void SaveDataSpawner(EnemyRespawn respawn)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    string path = "E:/Survival Game/Survival MINI Game/Assets/Data" + spawnDatafile;
    //    FileStream stream = new FileStream(path, FileMode.Create);

    //    Debug.Log("File has Create!");
    //    formatter.Serialize(stream, spawndata);
    //    stream.Close();
    //}

    //public static MonsterDataContainer LoadMonster()
    //{
    //    string path = Application.persistentDataPath + monsterDatafile;
    //    if (File.Exists(path))
    //    {
    //        BinaryFormatter formatter = new BinaryFormatter();
    //        FileStream stream = new FileStream(path, FileMode.Open);

    //        MonsterDataContainer monsdata = formatter.Deserialize(stream) as MonsterDataContainer;
    //        stream.Close();
    //        return monsdata;
    //    }
    //    else
    //    {
    //        Debug.LogError("File Not Found!");
    //        return null;
    //    }
    //}
    //public static SpawnDataContainer LoadSpawner()
    //{
    //    string path = Application.persistentDataPath + spawnDatafile;
    //    if (File.Exists(path))
    //    {
    //        BinaryFormatter formatter = new BinaryFormatter();
    //        FileStream stream = new FileStream(path, FileMode.Open);

    //        SpawnDataContainer spawndata = formatter.Deserialize(stream) as SpawnDataContainer;
    //        stream.Close();
    //        return spawndata;
    //    }
    //    else
    //    {
    //        Debug.LogError("File Not Found!");
    //        return null;
    //    }
    //}


    //private string LoadFromFile(string file)
    //{
    //    string path = Application.persistentDataPath + "/" + file;
    //    if (File.Exists(path))
    //    {
    //        FileStream stream = new FileStream(path, FileMode.Open);
    //        using(StreamReader reader = new StreamReader(path)) 
    //        {
    //            string json = reader.ReadToEnd();
    //            return json;
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("File Not Found");
    //        return "";
    //    }
    //}
}

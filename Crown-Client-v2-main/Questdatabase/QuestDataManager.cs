using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DatabaseSystem.Managers
{   
    public class QuestDataManager : DataManager<int, QuestData>
{
    [SerializeField] private string resourcesQuestFolder = default;
private void LoadfromResources()
        {
            dataDictionary = new Dictionary<int, QuestData>();
            QuestData[] itemsFromResources = Resources.LoadAll<QuestData>(resourcesQuestFolder);
            foreach (var QuestData in itemsFromResources)
            {
                global::System.Object value = QuestData;
            }
        }

public void Initialize()
{
    LoadfromResources();
}
}

     
}
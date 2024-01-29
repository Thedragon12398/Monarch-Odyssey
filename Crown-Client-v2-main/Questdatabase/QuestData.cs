using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Create Quest", menuName = "Create QuestData")]

public class QuestData : ScriptableObject
{
  private int id = default;
   private string displayName = default;
   private int QuestType = default;
   private int Duration = default;
   private string QuestDescription = default;
   private int Repeatable = default;
   private int XP_Awarded = default;
   private int Energy_Awarded = default;
   private int Lat = default; 
   private int Long = default;
   private int steps = default;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox;

namespace DatabaseSystem.ScriptableObjects 
{
    [CreateAssetMenu (menuName = "Data/Quests/ Quest Data")]
    public class QuestData : ScriptableObject
    {
        [SerializeField] private int id = default;
        [SerializeField] private string displayName = default;
        [SerializeField] private int QuestType = default;
        [SerializeField] private int Duration = default;
        [SerializeField] private string QuestDescription = default;
        [SerializeField] private int Repeatable = default;
        [SerializeField] private int XP_Awarded = default;
        [SerializeField] private int Energy_Awarded = default;
        [SerializeField] private int Lat = default; 
        [SerializeField] private int Long = default;
        [SerializeField] private int steps = default;

        public global::System.Int32 Id { get => id; set => id = value; }
        public global::System.String DisplayName { get => displayName; set => displayName = value; }
        public global::System.Int32 QuestType1 { get => QuestType; set => QuestType = value; }
        public global::System.Int32 Duration1 { get => Duration; set => Duration = value; }
        public global::System.String QuestDescription1 { get => QuestDescription; set => QuestDescription = value; }
        public global::System.Int32 Repeatable2 { get => Repeatable; set => Repeatable = value; }
        public global::System.Int32 XP_Awarded1 { get => XP_Awarded; set => XP_Awarded = value; }
        public global::System.Int32 Energy_Awarded1 { get => Energy_Awarded; set => Energy_Awarded = value; }
        public global::System.Int32 Long1 { get => Long; set => Long = value; }
        public global::System.Int32 Steps { get => steps; set => steps = value; }
    }
}

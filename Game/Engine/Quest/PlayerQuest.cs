namespace Game.Engine
{
    public class PlayerQuest
    {
        public Quest.Quest Details { get; set; }
        public bool IsCompleted { get; set; }
 
        public PlayerQuest(Quest.Quest details)
        {
            Details = details;
            IsCompleted = false;
        }
    }
}
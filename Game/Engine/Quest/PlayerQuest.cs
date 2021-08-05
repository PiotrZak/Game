namespace Game.Engine
{
    public class PlayerQuest
    {
        private Quest.Quest Details { get; set; }
        private bool IsCompleted { get; set; }
 
        public PlayerQuest(Quest.Quest details)
        {
            Details = details;
            IsCompleted = false;
        }
    }
}
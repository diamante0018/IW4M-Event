namespace IW4M_Event
{
    public class AFKEvent
    {
        public string Name { get; set; }
        public long Guid { get; set; }
        public int Id => GetHashCode();

        public static AFKEvent Parse(string name, long PlayerGUID)
        {
            var parsedEvent = new AFKEvent()
            {
                Guid = PlayerGUID,
                Name = name
            };

            return parsedEvent;
        }
    }
}

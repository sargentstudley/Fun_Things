namespace participantapi.Lookups
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;

    // Nested classes generated with http://json2csharp.com/
    public class PinLookup
    {
        public PinLookup()
        {
            var jsonString = File.ReadAllText("./Lookups/PinLevels/RawData.json");
            this.Data = JsonSerializer.Deserialize<DataRoot>(jsonString);
        }

        public DataRoot Data { get; private set; }

        public class DataRoot
        {
            public List<PinGroup> PinGroups { get; set; }
            public List<Note> Notes { get; set; }
        }

        public class ScoreOption
        {
            public int Distance_Meters { get; set; }
            public int TargetSize_cm { get; set; }
            public int Score { get; set; }
            public string Note { get; set; }
        }

        public class Pin
        {
            public int PinLevel { get; set; }
            public string PinName { get; set; }
            public List<ScoreOption> ScoreOptions { get; set; }
        }

        public class PinGroup
        {
            public string Class { get; set; }
            public string Local { get; set; }
            public string BowType { get; set; }
            public string Description { get; set; }
            public string Summary { get; set; }
            public string SourceData { get; set; }
            public List<Pin> Pins { get; set; }
            public string Notes { get; set; }
        }

        public class Note
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}
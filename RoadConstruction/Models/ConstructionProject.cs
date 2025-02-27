namespace RoadConstruction.Models
{
    public class ConstructionProject
    {
        public DateTimeOffset SamplingTime { get; set; }
        public string ProjectName { get; set; }
        public int? ConstructionCount { get; set; }
        public bool IsConstructionCompleted { get; set; }
        public decimal RoadLength { get; set; }
    }

}

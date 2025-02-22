namespace NeuroAssist.Models
{
    public class BrainScan : BaseEntity
    {
        public string ImagePath { get; set; }  
        
        public string Size { get; set; }  
        
        public string Location { get; set; }  
        
        public string Description { get; set; }  
        
    }
}

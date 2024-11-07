namespace Eccomerce_Full_Stack.Models
{
    public class ListModels
    {
        public string Href { get; set; }
        public string Label { get; set; }
    }

    public class DropdownModels
    {
        // Properly initialize the list
        public List<ListModels> Models { get; set; } = new List<ListModels>();
    }
}
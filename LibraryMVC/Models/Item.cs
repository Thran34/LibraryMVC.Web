using System.ComponentModel;

namespace LibraryMVC.Models
{
    public class Item
    {
        [DisplayName("Identity")]
        public int Id { get; set; }
        [DisplayName("Title")]
        public string Name { get; set; }
        [DisplayName("Genre")]
        public string TypeName { get; set; }
    }
}

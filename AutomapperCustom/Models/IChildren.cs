using AutomapperTest.Models;

namespace AutomapperCustom.Models
{
    public interface IChildren
    {
        string Name { get; set; }
        string FatherName { get; set; }
        ChildrenCollection childrenCollection { get; set; }
    }
}
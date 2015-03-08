using TechTest.Entity;

namespace TechTest.Core.Models
{
    public class ColourModel
    {
        public ColourModel()
        {
        }

        public ColourModel(Colour colour)
        {
            ColourId = colour.ColourId;
            Name = colour.Name;
        }

        public int ColourId { get; set; }
        public string Name { get; set; }

    }
}
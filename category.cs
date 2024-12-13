using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.Json;
using System.Xml.Schema;
using System.Runtime.CompilerServices;

public class Category
{
    public string name { get; set; }
    public string description { get; set; }

    public Category(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public List<Category> ageCategories()
    {
        var ageCategories = new List<Category>
        {
            new Category("Infant", "0-12 months old"),
            new Category("Toddler", "1-3 years old"),
            new Category("Preschool", "3-5 years old"),
            new Category("Kids", "6-12 years old"),
            new Category("Teens", "13+ years old")
        };

        return ageCategories;
}

    public List<Category> typeCategories()
    {
        var typeCategories = new List<Category>
        {
            new Category("Educational", "Toys that promote learning and skill development, focusing on subjects like math, science, and language."),
            new Category("Action Figures, Dolls, & Figurines", "Collectible or play toys representing characters, superheroes, or fictional figures."),
            new Category("Building Set", "Toys that allow children to construct models or structures using blocks, pieces, or parts."),
            new Category("Puzzles", "Toys designed to challenge problem-solving skills by fitting pieces together to form images or shapes."),
            new Category("Board Games", "Tabletop games involving strategy, luck, or teamwork, typically played with a board, cards, or dice."),
            new Category("Plushies", "Soft, stuffed toys that are cuddly and often designed to resemble animals or characters."),
            new Category("Electronic", "Toys that incorporate electronics for interactive or digital play, like robots, games, or gadgets."),
            new Category("Arts and Craft", "Supplies or kits for creative expression, such as coloring, painting, or making crafts."),
            new Category("Outdoor & Sports", "Toys designed for physical activity and play outside, including sporting goods and active toys."),
            new Category("Musical Instruments", "Toys that introduce children to music, such as mini keyboards, drums, or guitars."),
            new Category("Playsets", "Toys that recreate real-world environments (like a kitchen set or dollhouse) for imaginative play."),
            new Category("Vehicles", "Toys that include cars, trucks, trains, planes, and other forms of transport for play and exploration."),
            new Category("Game Consoles", "Electronic devices designed for video game play, often featuring interactive games for kids and adults.")
        };
        
        return typeCategories;
    }
}

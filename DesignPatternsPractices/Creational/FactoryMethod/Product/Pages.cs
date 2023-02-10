using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsPractices.Creational.FactoryMethod.Product
{
    public abstract class Pages
    {
        public string Name { get; set; }
    }

    public class SkillsPage : Pages
    {
        public SkillsPage()
        {
            Name = "Resume";
        }
    }

    public class EducationPage : Pages
    {
        public EducationPage()
        {
            Name = "Resume";
        }
    }

    public class ExperiencePage : Pages
    {
        public ExperiencePage()
        {
            Name = "Resume";
        }
    }

    public class IntroductionPage : Pages
    {
        public IntroductionPage()
        {
            Name = "Resume";
        }
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ResultsPage : Pages
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ConclusionPage : Pages
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class SummaryPage : Pages
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class BibliographyPage : Pages
    {
    }


}

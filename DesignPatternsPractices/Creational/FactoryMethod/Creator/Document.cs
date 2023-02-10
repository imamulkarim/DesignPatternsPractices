using DesignPatternsPractices.Creational.FactoryMethod.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsPractices.Creational.FactoryMethod.Creator
{

    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    abstract class Document
    {
        private List<Pages> _pages = new List<Pages>();
        // Constructor calls abstract Factory method
        public Document()
        {
            this.CreatePages();
        }
        public List<Pages> Pages
        {
            get { return _pages; }
        }
        // Factory Method
        public abstract void CreatePages();
    }


    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class Resume : Document
    {
        // Factory Method implementation
        public override void CreatePages()
        {
            Pages.Add(new SkillsPage());
            Pages.Add(new EducationPage());
            Pages.Add(new ExperiencePage());
        }
    }
    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class Report : Document
    {
        // Factory Method implementation
        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ResultsPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());
        }
    }
}

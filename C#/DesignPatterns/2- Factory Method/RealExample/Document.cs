using System.Collections.Generic;

namespace DesignPatterns._2__Factory_Method.RealExample
{
    public abstract class Document
    {
        private List<Page> _pages = new List<Page>();

        public List<Page> Pages => _pages;

        public Document()
        {
            this.CreatePages();
        }

        public abstract void CreatePages();
    }
}

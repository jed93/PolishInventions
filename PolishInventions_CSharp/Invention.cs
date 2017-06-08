using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace PolishInventions_CSharp
{
    public class Invention
    {
        public string ApplicationNumber { get; set; }
        public string ExclusiveRightNumber { get; set; }
        public string PriorityDate { get; set; }
        public string ApplicationDate { get; set; }
        public string BupNumber { get; set; }
        public string BupPublicationDate { get; set; }
        public string WupNumber { get; set; }
        public string WupPublicationDate { get; set; }
        public string Title { get; set; }
        public string AuthorisedPeople { get; set; }
        public string Creators { get; set; }
        public string Proxies { get; set; }
        public string MkpClassification { get; set; }
        public string CaseStatus { get; set; }
    }

    public sealed class InventionMap : CsvClassMap<Invention>
    {
        public InventionMap()
        {
            Map(m => m.ApplicationNumber).Name("Numer_zgloszenia");
            Map(m => m.ExclusiveRightNumber).Name("Numer_prawa_wylacznego");
            Map(m => m.PriorityDate).Name("Data_pierwszenstwa");
            Map(m => m.ApplicationDate).Name("Data_zgloszenia");
            Map(m => m.BupNumber).Name("Numer_BUP");
            Map(m => m.BupPublicationDate).Name("Data_Publikacji_BUP");
            Map(m => m.WupNumber).Name("Numer_WUP");
            Map(m => m.WupPublicationDate).Name("Data_Publikacji_WUP");
            Map(m => m.Title).Name("Tytul");
            Map(m => m.AuthorisedPeople).Name("Uprawnieni");
            Map(m => m.Creators).Name("Tworcy");
            Map(m => m.Proxies).Name("Pelnomocnicy");
            Map(m => m.MkpClassification).Name("Klasyfikacja_MKP");
            Map(m => m.CaseStatus).Name("Status_sprawy");
        }
    }
}

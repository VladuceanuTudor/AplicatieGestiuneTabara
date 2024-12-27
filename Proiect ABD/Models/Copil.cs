using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabaraDeVaraApp.Models
{
    [Table(Name = "Copil")]
    public class Copil
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int CopilID { get; set; }

        [Column(CanBeNull = false)]
        public string Nume { get; set; }

        [Column(CanBeNull = false)]
        public string Prenume { get; set; }

        [Column(CanBeNull = false)]
        public int Varsta { get; set; }

        [Column(CanBeNull = false)]
        public string Parola { get; set; }

        [Column(CanBeNull = false)]
        public int EducatorID { get; set; }

        // Navigation property for Educator
        private EntityRef<Educator> _Educator;
        [Association(Storage = "_Educator", ThisKey = "EducatorID", OtherKey = "EducatorID", IsForeignKey = true)]
        public Educator Educator
        {
            get { return this._Educator.Entity; }
            set { this._Educator.Entity = value; }
        }

        // Navigation property for related Parinte entities
        private EntitySet<CopilParinte> _CopilParinte;
        [Association(Storage = "_CopilParinte", OtherKey = "CopilID", ThisKey = "CopilID")]
        public EntitySet<CopilParinte> CopilParinte
        {
            get { return this._CopilParinte; }
            set { this._CopilParinte.Assign(value); }
        }

        // Navigation property for related Activitate entities
        private EntitySet<CopilActivitate> _CopilActivitate;
        [Association(Storage = "_CopilActivitate", OtherKey = "CopilID", ThisKey = "CopilID")]
        public EntitySet<CopilActivitate> CopilActivitate
        {
            get { return this._CopilActivitate; }
            set { this._CopilActivitate.Assign(value); }
        }

        public Copil()
        {
            _CopilParinte = new EntitySet<CopilParinte>();
            _CopilActivitate = new EntitySet<CopilActivitate>();
        }
    }

}

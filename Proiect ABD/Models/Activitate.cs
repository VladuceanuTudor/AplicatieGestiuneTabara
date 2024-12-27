using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabaraDeVaraApp.Models
{
    [Table(Name = "Activitate")]
    public class Activitate
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ActivitateID { get; set; }

        [Column(CanBeNull = false)]
        public string Denumire { get; set; }

        [Column(CanBeNull = false)]
        public DateTime DataOra { get; set; }

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

        // Navigation property for related Copil entities through CopilActivitate
        private EntitySet<CopilActivitate> _CopilActivitate;
        [Association(Storage = "_CopilActivitate", OtherKey = "ActivitateID", ThisKey = "ActivitateID")]
        public EntitySet<CopilActivitate> CopilActivitate
        {
            get { return this._CopilActivitate; }
            set { this._CopilActivitate.Assign(value); }
        }

        public Activitate()
        {
            _CopilActivitate = new EntitySet<CopilActivitate>();
        }
    }

}

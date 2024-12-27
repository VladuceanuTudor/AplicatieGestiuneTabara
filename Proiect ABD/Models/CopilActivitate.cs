using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabaraDeVaraApp.Models
{
    [Table(Name = "CopilActivitate")]
    public class CopilActivitate
    {
        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public int CopilID { get; set; }

        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public int ActivitateID { get; set; }

        // Navigation property for Copil
        private EntityRef<Copil> _Copil;
        [Association(Storage = "_Copil", ThisKey = "CopilID", OtherKey = "CopilID", IsForeignKey = true)]
        public Copil Copil
        {
            get { return this._Copil.Entity; }
            set { this._Copil.Entity = value; }
        }

        // Navigation property for Activitate
        private EntityRef<Activitate> _Activitate;
        [Association(Storage = "_Activitate", ThisKey = "ActivitateID", OtherKey = "ActivitateID", IsForeignKey = true)]
        public Activitate Activitate
        {
            get { return this._Activitate.Entity; }
            set { this._Activitate.Entity = value; }
        }
    }

}

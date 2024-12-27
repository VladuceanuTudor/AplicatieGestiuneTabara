using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace TabaraDeVaraApp.Models
{
    [Table(Name = "CopilParinte")]
    public class CopilParinte
    {
        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public int CopilID { get; set; }

        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public int ParinteID { get; set; }

        // Navigation property for Copil
        private EntityRef<Copil> _Copil;
        [Association(Storage = "_Copil", ThisKey = "CopilID", OtherKey = "CopilID", IsForeignKey = true)]
        public Copil Copil
        {
            get { return this._Copil.Entity; }
            set { this._Copil.Entity = value; }
        }

        // Navigation property for Parinte
        private EntityRef<Parinte> _Parinte;
        [Association(Storage = "_Parinte", ThisKey = "ParinteID", OtherKey = "ParinteID", IsForeignKey = true)]
        public Parinte Parinte
        {
            get { return this._Parinte.Entity; }
            set { this._Parinte.Entity = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabaraDeVaraApp.Models
{
    [Table(Name = "Parinte")]
    public class Parinte
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ParinteID { get; set; }

        [Column(CanBeNull = false)]
        public string Nume { get; set; }

        [Column(CanBeNull = false)]
        public string Prenume { get; set; }

        [Column(CanBeNull = false)]
        public string Parola { get; set; }

        [Column(CanBeNull = false)]
        public string NumarTel { get; set; }

        [Column(CanBeNull = false)]
        public string Email { get; set; }

        // Navigation property for related Copil entities
        private EntitySet<CopilParinte> _CopilParinte;
        [Association(Storage = "_CopilParinte", OtherKey = "ParinteID", ThisKey = "ParinteID")]
        public EntitySet<CopilParinte> CopilParinte
        {
            get { return this._CopilParinte; }
            set { this._CopilParinte.Assign(value); }
        }

        public Parinte()
        {
            _CopilParinte = new EntitySet<CopilParinte>();
        }
    }

}

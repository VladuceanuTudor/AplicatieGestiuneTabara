using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabaraDeVaraApp.Models
{
    [Table(Name = "Educator")]
    public class Educator
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int EducatorID { get; set; }

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
        private EntitySet<Copil> _Copii;
        [Association(Storage = "_Copii", OtherKey = "EducatorID", ThisKey = "EducatorID")]
        public EntitySet<Copil> Copii
        {
            get { return this._Copii; }
            set { this._Copii.Assign(value); }
        }

        // Navigation property for related Activitate entities
        private EntitySet<Activitate> _Activitati;
        [Association(Storage = "_Activitati", OtherKey = "EducatorID", ThisKey = "EducatorID")]
        public EntitySet<Activitate> Activitati
        {
            get { return this._Activitati; }
            set { this._Activitati.Assign(value); }
        }

        public Educator()
        {
            _Copii = new EntitySet<Copil>();
            _Activitati = new EntitySet<Activitate>();
        }
    }

}

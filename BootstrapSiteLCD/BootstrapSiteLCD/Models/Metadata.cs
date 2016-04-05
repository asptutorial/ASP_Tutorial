using System;
using System.ComponentModel.DataAnnotations;

namespace BootstrapSiteLCD.Models
{
    public class AddressMetadata
    {
        [Display(Name = "Straße")]
        public string Street;

        [Display(Name = "Hausnummer")]
        public string StreetNo;

        [Display(Name = "Zusatz")]
        public string Appendix;

        [Display(Name = "City ID")]
        public int CityId;

        [Display(Name = "Postleitzahl")]
        public int Postcode;

        [Display(Name = "Student")]
        public int Student;

        [Display(Name = "ID")]
        public int Id;
    }

    public class StudentMetadata
    {
        [Display(Name = "Matrikel-Nr.")]
        public int MatriculationNo;

        [Display(Name = "Vorname")]
        public string Prename;

        [Display(Name = "Nachname")]
        public string Surname;

        [Display(Name = "Geburtsdatum")]
        public Nullable<System.DateTime> Birthday;

        [Display(Name = "Geburtsort")]
        public string Birthplace;

        [Display(Name = "Prüfungs-Nr.")]
        public int ExaminationNo;

        [Display(Name = "Aktiv")]
        public byte Activ;

        [Display(Name = "Einschreibung")]
        public Nullable<System.DateTime> Registrationdate;

        [Display(Name = "Studium-Ende")]
        public Nullable<System.DateTime> Expirationdate;

        [Display(Name = "ID")]
        public int Id;
    }

    public class CountryMetadata
    {
        [Display(Name = "Land")]
        public string Name;

        [Display(Name = "ID")]
        public int Id;
    }

    public class CityMetadata
    {
        [Display(Name = "Stadt")]
        public string Name;

        [Display(Name = "ID")]
        public int Id;

        [Display(Name = "Land-ID")]
        public int CountryId;
    }
}
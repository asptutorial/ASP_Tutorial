using System;
using System.ComponentModel.DataAnnotations;
using BootstrapSiteLCD.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Globalization;

namespace BootstrapSiteLCD.Models
{
    [MetadataType(typeof(AddressMetadata))]
    public partial class Address
    {
    }

    [MetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
    }

    [MetadataType(typeof(CountryMetadata))]
    public partial class Country
    {
    }

    [MetadataType(typeof(CityMetadata))]
    public partial class City
    {
    }
}

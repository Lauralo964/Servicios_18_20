namespace Servicios_18_20.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class PRODucto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODucto()
        {
            this.DEtalleFActuras = new HashSet<DEtalleFActura>();
            this.DEtalleFacturaCompras = new HashSet<DEtalleFacturaCompra>();
            this.PRoductoPRoveedors = new HashSet<PRoductoPRoveedor>();
        }
    
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int ValorUnitario { get; set; }
        public int CodigoTipoProducto { get; set; }
        public Nullable<bool> Activo { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEtalleFActura> DEtalleFActuras { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEtalleFacturaCompra> DEtalleFacturaCompras { get; set; }
        [JsonIgnore]
        public virtual TIpoPRoducto TIpoPRoducto { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRoductoPRoveedor> PRoductoPRoveedors { get; set; }
    }
}

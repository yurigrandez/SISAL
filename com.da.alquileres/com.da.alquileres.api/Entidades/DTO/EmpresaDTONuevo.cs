﻿namespace com.da.alquileres.api.Entidades.DTO
{
    public class EmpresaDTONuevo
    {
        public string? nombre { get; set; }
        public string? direccion { get; set; }
        public string? ruc { get; set; }
        public string? telefono { get; set; }
        public string? movil { get; set; }
        public string? nombreContacto { get; set; }
        public string? correoContacto { get; set; }
        public string? tlfContacto { get; set; }
        public string? movilContacto { get; set; }
        public byte[]? imgEmpresa { get; set; }
    }
}

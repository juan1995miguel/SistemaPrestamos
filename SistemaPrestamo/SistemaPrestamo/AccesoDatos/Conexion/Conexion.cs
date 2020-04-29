using AccesoDatos.Models;
using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Conexion
{
    public class Conexion : DataConnection
    {
        public Conexion() : base("connSystemPrestamo") { }
        
        /*Objetos de colecion de datos... Obtener las referecias de las tablas */

        public ITable<TClientes> clientes { get { return GetTable<TClientes>(); } }
        public ITable<TDatosLaborables> datosLaborables { get { return GetTable<TDatosLaborables>(); } }
        public ITable<TReferencias> referencias { get { return GetTable<TReferencias>(); } }
        public ITable<TClasePrestamos> clasePrestamos { get { return GetTable<TClasePrestamos>(); } }
        public ITable<TFormaPagos> formaPagos { get { return GetTable<TFormaPagos>(); } }
        public ITable<TRutas> rutas { get { return GetTable<TRutas>(); } }
        public ITable<TTasaInteres> tasaInteres { get { return GetTable<TTasaInteres>(); } }
        public ITable<TTasaMoras> tasaMoras { get { return GetTable<TTasaMoras>(); } }
        public ITable<TTipoGarantias> tipoGarantias { get { return GetTable<TTipoGarantias>(); } }
        public ITable<TTipoPrestamos> tipoPrestamos { get { return GetTable<TTipoPrestamos>(); } }
        public ITable<TZonas> zonas { get { return GetTable<TZonas>(); } }
        public ITable<TGestores> gestores { get { return GetTable<TGestores>(); } }
        public ITable<TSolicitudes> solicitudes { get { return GetTable<TSolicitudes>(); } }
        public ITable<TDetalleSolicitudes> detalleSolicitudes { get { return GetTable<TDetalleSolicitudes>(); } }
        public ITable<TEstadoSolicitudes> estadoSolicitudes { get { return GetTable<TEstadoSolicitudes>(); } }
        public ITable<TGarantiaEconomica> garantiaEconomicas { get { return GetTable<TGarantiaEconomica>(); } }
        public ITable<TEstadoCuotas> estadoCuotas { get { return GetTable<TEstadoCuotas>(); } }
        public ITable<TReportePrestamos> reportePrestamos { get { return GetTable<TReportePrestamos>(); } }
        public ITable<TNotasSolicitudes> notasSolicitudes { get { return GetTable<TNotasSolicitudes>(); } }
        public ITable<TEstadoPrestamos> estadoPrestamos { get { return GetTable<TEstadoPrestamos>(); } }
        public ITable<TReportePagos> reportePagos { get { return GetTable<TReportePagos>(); } }
        public ITable<TAtrasos> atraso { get { return GetTable<TAtrasos>(); } }
        public ITable<TTipoPagos> tipoPagos { get { return GetTable<TTipoPagos>(); } }
        public ITable<TDistribucionPagos> distribucionPagos { get { return GetTable<TDistribucionPagos>(); } }
        public ITable<TCobros> cobros { get { return GetTable<TCobros>(); } }
        public ITable<TDetalleCobros> detalleCobros { get { return GetTable<TDetalleCobros>(); } }

    }
}

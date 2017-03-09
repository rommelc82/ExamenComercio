using BeExamen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfXml
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISucursales 
    {

        [OperationContract]
        List<sucursal> list(int? idbanco);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    //[DataContract]
    //public class sucursal : sucursal
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]       
    //    public sucursal()
    //    {
    //        ordenpagoes = new HashSet<ordenpago>();
    //    }

    //    public int id { get; set; }

    //    public int? idbanco { get; set; }

    //    [DataMember]
    //    public string nombre { get; set; }

    //    [DataMember]
    //    public string direccion { get; set; }

    //    public DateTime? fecharegistro { get; set; }

    //    public virtual banco banco { get; set; }

    //    public virtual ICollection<ordenpago> ordenpagoes { get; set; }
    //}
}

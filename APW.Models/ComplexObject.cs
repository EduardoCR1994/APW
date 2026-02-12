using APW.Models.Entities;
using System.Text.Json.Serialization;

namespace APW.Models
{
    public class ComplexObject
    {
        public string Indentifier { get { return _uniqueIndentifier; } } 
        private string _uniqueIndentifier { get; set;  } = Guid.NewGuid().ToString(); //Genera un nuevo GUID como valor predeterminado para UniqueIndentifier, lo que garantiza que cada instancia de ComplexObject tenga un identificador único incluso si no se proporciona uno explícitamente al crear el objeto.
    
        public IEnumerable<object> Entities { get; set; }

        public List<string> Errors { get; set; } = [];
    }

}

using System.Data;

namespace api_LS.Entities{
    public class Respuesta{
        
        public DataTable data { get; set; }
        public string Mensaje { get; set; }
        
        public Respuesta(){
            
        }
        
    
        public Respuesta(DataTable Data, string Mensaje){
            this.data=Data;
            this.Mensaje=Mensaje;
        }
        
    }
}
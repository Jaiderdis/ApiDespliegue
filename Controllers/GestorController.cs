using System.Data;
using api_LS.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace api_LS.Controllers;

[ApiController]
[Route("[controller]")]
public class GestorController:ControllerBase{
    
    [HttpGet]
    [Route("/Productos")]
    public IActionResult ConsultarProductos()
    {
        Respuesta res=new Respuesta();
        string json;
        Connection Con=new Connection();
        res=Con.Consultar("Select * from producto");
        json = JsonConvert.SerializeObject(res);
        return Ok(json);


    }
    [HttpGet]
    [Route("/usuarios")]
    public IActionResult ConsultarUsuarios()
    {
        Respuesta res=new Respuesta();
        string json;
        Connection Con=new Connection();
        res=Con.Consultar("Select * from Usuario");
        json = JsonConvert.SerializeObject(res);
        return Ok(json);


    }

    [HttpPost]
    [Route("/insertarProducto")]
    public IActionResult insertarProducto(Producto product)
    {

        Connection Con=new Connection();
        string mensaje=Con.insert($"EXECUTE insertProducto {product.IdCategoria},'{product.nombre}',{product.precio},{product.cantidad},'{DateTime.Now.ToString("yyyy/MM/dd HH:mm")}',{product.estado}");
        
        return Ok(mensaje);


    }

    [HttpPost]
    [Route("/insertarUsuario")]
    public IActionResult insertarUsuario(Usuario user)
    {

        Connection Con=new Connection();
        string mensaje=Con.insert($"EXECUTE insertUsuario {user.Rol},'{user.NombreUsuario}','{user.Nombre}','{user.Correo}','{DateTime.Now.ToString("yyyy/MM/dd HH:mm")}','{user.Correo}',{user.cedula}");
        
        return Ok(mensaje);


    }
    
}
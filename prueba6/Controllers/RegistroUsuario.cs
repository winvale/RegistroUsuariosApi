using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba6.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace prueba6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroUsuario : ControllerBase
    {
            private readonly AplicationDbContext _context;
            public RegistroUsuario(AplicationDbContext context) 
            { 
                 _context = context;
            }
       
    // GET: api/<RegistroUsuario>
    [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listarUsuarios = await _context.RegistroUsuarios.ToListAsync();
                return Ok(listarUsuarios);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

        }

       

        // POST api/<RegistroUsuario>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegistroUsuarios registro)
        {
            try
            {
                _context.Add(registro);
                await 
                    _context.SaveChangesAsync();
                return Ok(registro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<RegistroUsuario>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RegistroUsuarios registro)
        {
            try
            {
                if (id != registro.Id) {
                    return NotFound();
                }
                _context.Update(registro);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Registro Actualizado con exito" });

            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }   
        }

        // DELETE api/<RegistroUsuario>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try 
            { 
                var registro = await _context.RegistroUsuarios.FindAsync(id);
                if (registro == null) {
                    return NotFound();
                }
                _context.RegistroUsuarios.Remove(registro);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El registro fue eliminado con exito" });
            }
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Context;
using SistemaVendas.Dto;
using SistemaVendas.Models;

namespace SistemaVendas.Repository
{
    public class ClienteRepository
    {
        private readonly VendasContext _context;

        public ClienteRepository(VendasContext context)
        {
            _context = context;
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public Cliente ObterPorId(int id)
        {
            var cliente = _context.Clientes.Find(id);
            return cliente;
        }

        public Cliente ObterPorNome(string nome)
        {
            var cliente = _context.Clientes.Find(nome);
            return cliente;
        }

        public Cliente AtualizarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public void AtualizarSenha(Cliente cliente, AtualizarSenhaClienteDTO dto)
        {
            cliente.Senha = dto.Senha;
            AtualizarCliente(cliente);
        }

        public void DeletarPedido(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }
    }
}
using Util;
using System;
using System.Linq;
using BLL.Interfaces;
using DAL.Interfaces;
using Model.Entidades;
using Util.Exceptions;
using Infra.Interfaces;

namespace BLL
{
    public class UsuarioBusiness : Business<Usuario>, IUsuarioBusiness
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioBusiness(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork) : base(usuarioRepository)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
        }

        public Usuario ObterPorEmail(string email) => _usuarioRepository.Obter(p => p.Email == email.Trim());

        public IQueryable<Usuario> Listar() => _usuarioRepository.ObterListaQueryable();

        public override void Atualizar(Usuario usuario)
        {
            var usuarioDb = _usuarioRepository.ObterPorId(usuario.Id);

            if (usuarioDb == null)
                throw new S2ItException($"Usuário com id {usuario.Id} inválido");

            if (!usuarioDb.Senha.Equals(usuario.Senha))
                usuarioDb.Senha = Criptografia.Criptografar(usuario.Senha);

            if (!usuarioDb.Email.Equals(usuario.Email, StringComparison.OrdinalIgnoreCase))
            {
                if (!Validacao.ValidarEmail(usuario.Email))
                    throw new S2ItException($"Email {usuario.Email} inválido.");

                usuarioDb.Email = usuario.Email;
            }

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Ativo = usuario.Ativo;
            _usuarioRepository.Atualizar(usuarioDb);
            _unitOfWork.Commit();
        }

        public void Deletar(int id)
        {
            var usuario = _usuarioRepository.ObterPorId(id);

            if (usuario == null)
                throw new S2ItException($"Não foi encontrado nenhum usuário com id {id}");

            _usuarioRepository.Excluir(usuario);
            _unitOfWork.Commit();
        }

        public void Cadastrar(Usuario usuario)
        {
            usuario.Senha = Criptografia.Criptografar(usuario.Senha);

            if (!Validacao.ValidarEmail(usuario.Email))
                throw new S2ItException($"Email {usuario.Email} inválido.");

            usuario.DataCadastro = DateTime.Now;
            _usuarioRepository.Adicionar(usuario);
            _unitOfWork.Commit();
        }
    }
}
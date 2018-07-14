using BitEng.Security.Model;
using Furnies.Domain;
using Furnies.Domain.Entities.Accounts;
using Furnies.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNet.Identity;
using BitEng.Security;
using System.Transactions;
using BitEng.Security.Stores;
using BitEng.Security.Managers;

namespace Furnies.Application.Usuarios
{
    public class UsuarioAppService: IDisposable
    {
        private FurniesContext _context;

        private UsuarioRepository _usuarioRepository;

        public UsuarioAppService(FurniesContext context)
        {
            _context = context;
            _usuarioRepository = new UsuarioRepository(_context);
        }

        public ServiceResult<Usuario> Create(CreateUsuario createUsuario) {
            try
            {
                IdentityResult result = null;
                Usuario usuario = null;
                var user = new BitUser { UserName = createUsuario.Email, Email = createUsuario.Email, EmailConfirmed = createUsuario.EmailConfirmed };
                //adding roles
                if (createUsuario.RolesIds.Length > 0) {
                    foreach (var roleId in createUsuario.RolesIds)
                        user.Roles.Add(new BitUserRole { RoleId = roleId });
                }
                var securityContext = new BitSecurityContext();
                BitUserManager userManager = new BitUserManager(new BitUserStore(securityContext));
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    result = userManager.Create(user, createUsuario.Password);
                    if (result.Succeeded)
                    {
                        usuario = new Usuario { Id = user.Id, Email = user.Email };
                        _usuarioRepository.Insert(usuario);
                        _context.SaveChanges();
                    }
                    else {
                        OperationError error = new OperationError(ErrorType.Validation, string.Join(",",result.Errors));
                        return new ServiceResult<Usuario>(OperationStatus.Error, error);
                    }
                    scope.Complete();
                }
                
                return new ServiceResult<Usuario>(OperationStatus.Succeed, usuario);
            }
            catch (Exception ex)
            {
                OperationError error = new OperationError(ErrorType.Exception,"No se realizó la inserción",ex);
                return new ServiceResult<Usuario>(OperationStatus.Error, error);
            }
        }

        public ServiceResult<Usuario> Update(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Update(usuario);
                _context.SaveChanges();
                return new ServiceResult<Usuario>(OperationStatus.Succeed, usuario);
            }
            catch (Exception ex)
            {
                OperationError error = new OperationError(ErrorType.Exception, "No se realizó la actualización", ex);
                return new ServiceResult<Usuario>(OperationStatus.Error, error);
            }
        }

        public List<Usuario> Get(UsuarioQuery query, string order = "") {
            var result = _usuarioRepository.Query(query.Query(), order);
            return result.ToList();
        }

        public PagedResult<Usuario> GetPaged(UsuarioQuery query, string order, int page = 0, int pageSize = 10)
        {
            int totalPagesResult = 0;
            int totalRowsResult = 0;
            var queryResult = _usuarioRepository.QueryPage(query.Query(), out totalPagesResult, out totalRowsResult, order, page, pageSize);
            var result = new PagedResult<Usuario>(totalPagesResult, totalRowsResult, queryResult.ToList());
            return result;
        }
        public virtual Usuario Find(params object[] keyValues)
        {
            return _usuarioRepository.Find(keyValues);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

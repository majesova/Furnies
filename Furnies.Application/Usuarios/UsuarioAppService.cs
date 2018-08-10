using BitEng.Security.Model;
using Furnies.Domain;
using Furnies.Domain.Entities.Accounts;
using Furnies.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ServiceResult<Usuario> Create(CreateUsuarioDto createUsuario) {
            ServiceResult<Usuario> result;
            try
            {
                IdentityResult idenityResult = null;
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
                    idenityResult = userManager.Create(user, createUsuario.Password);
                    if (idenityResult.Succeeded)
                    {
                        usuario = new Usuario { Id = user.Id, Email = user.Email };
                        _usuarioRepository.Insert(usuario);
                        _context.SaveChanges();
                    }
                    else {
                        result = new ServiceErrorResult<Usuario>(new OperationError(ErrorType.Validation, string.Join(",", idenityResult.Errors)));
                    }
                    scope.Complete();
                }
                
                result = new ServiceSucceedResult<Usuario>(usuario);
            }
            catch (Exception ex)
            {
                OperationError error = new OperationError(ErrorType.Exception,"No se realizó la inserción",ex);
                result = new ServiceErrorResult<Usuario>(ErrorType.Exception,"No se insertó", ex);
            }
            return result;
        }

        public ServiceResult<Usuario> Update(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Update(usuario);
                _context.SaveChanges();
                return new ServiceSucceedResult<Usuario>(usuario);
            }
            catch (Exception ex)
            {
                OperationError error = new OperationError(ErrorType.Exception, "No se realizó la actualización", ex);
                return new ServiceSucceedResult<Usuario>(usuario);
            }
        }

        public List<Usuario> Get(IQueryObject<Usuario> query, string order = "") {
            var result = _usuarioRepository.Query(query.Query(), order);
            return result.ToList();
        }

        public PagedResult<Usuario> GetPaged(IQueryObject<Usuario> query, string order, int page = 0, int pageSize = 10)
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

using BitEng.Security.Model;
using BitEng.Security.Providers;
using BitEng.Security.Services;
using BitEng.Security.Stores;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEng.Security.Managers
{
    public class BitUserManager : UserManager<BitUser, Guid>
    {
        public BitUserManager(IUserStore<BitUser, Guid> store) : base(store)
        {
        }

        public static BitUserManager Create(IdentityFactoryOptions<BitUserManager> options, IOwinContext context)
        {

            var userStore = new BitUserStore(context.Get<BitSecurityContext>());
            var manager = new BitUserManager(userStore);
            // Configure la lógica de validación de nombres de usuario

            manager.UserValidator = new BitUserValidator(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true,
            };

            // Configure la lógica de validación de contraseñas
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = false,
            };

            // Configurar valores predeterminados para bloqueo de usuario
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Registre proveedores de autenticación en dos fases. Esta aplicación usa los pasos Teléfono y Correo electrónico para recibir un código para comprobar el usuario
            // Puede escribir su propio proveedor y conectarlo aquí.
            manager.RegisterTwoFactorProvider("Código telefónico", new PhoneNumberTokenProvider<BitUser, Guid>
            {
                MessageFormat = "Su código de seguridad es {0}"
            });

            manager.RegisterTwoFactorProvider("Código de correo electrónico", new EmailTokenProvider<BitUser, Guid>
            {
                Subject = "Código de seguridad",
                BodyFormat = "Su código de seguridad es {0}"
            });

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new BitDataProtectorTokenProvider(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;

        }
    }
}

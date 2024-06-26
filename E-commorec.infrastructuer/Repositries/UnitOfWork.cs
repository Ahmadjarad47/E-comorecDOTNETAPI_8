using E_commorec.infrastructuer.Data;
using E_commorec.infrastructuer.Repositries.Users;
using E_ommorec.core.Entity;
using E_ommorec.core.InterFace;
using E_ommorec.core.InterFace.User;
using E_ommorec.core.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commorec.infrastructuer.Repositries
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly UserManager<AppUsers> userManager;
        private readonly IGenerateTokenService generateTokenService;
        private readonly IEmailService emailService;
        private readonly AppDbContext appDbContext;
        private readonly UserManager<AppUsers> roleManager;
        public IUsers users { get; }

        public IAdminControllingUsers ControllingUsers { get; }

        public UnitOfWork(UserManager<AppUsers> userManager, IGenerateTokenService generateTokenService, IEmailService emailService, AppDbContext appDbContext, UserManager<AppUsers> roleManager)
        {
            this.generateTokenService = generateTokenService;
            this.userManager = userManager;
            this.emailService = emailService;
            this.appDbContext = appDbContext;
            users = new RegisterRepositries(userManager, generateTokenService, emailService);
            this.roleManager = roleManager;
            ControllingUsers = new AdminControllingUsers(appDbContext, roleManager);
        }
    }
}

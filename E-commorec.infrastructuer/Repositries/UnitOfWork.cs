﻿using AutoMapper;
using E_commorec.core.Entity;
using E_commorec.core.InterFace;
using E_commorec.core.InterFace.User;
using E_commorec.core.Services;
using E_commorec.infrastructuer.Data;
using E_commorec.infrastructuer.Repositries.Courses;
using E_commorec.infrastructuer.Repositries.Students;
using E_commorec.infrastructuer.Repositries.Teachers;
using E_commorec.infrastructuer.Repositries.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.FileProviders;

namespace E_commorec.infrastructuer.Repositries
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly UserManager<AppUsers> userManager;
        private readonly IGenerateTokenService generateTokenService;
        private readonly IEmailService emailService;
        private readonly AppDbContext appDbContext;
        private readonly UserManager<AppUsers> roleManager;
        private readonly IMemoryCache memoryCache;
        private readonly IMapper mapper;
        private readonly IFileProvider fileProvider;
        public IUsers users { get; }

        public IAdminControllingUsers ControllingUsers { get; }

        public IStudent Student { get; }

        public ITeacher Teacher { get; }

        public ICourse Course { get; }

        public ISubCourse SubCourse { get; }

        public INote note { get; }

        public ISupport support { get; }

        public UnitOfWork(UserManager<AppUsers> userManager, IGenerateTokenService generateTokenService, IEmailService emailService, AppDbContext appDbContext, UserManager<AppUsers> roleManager, IMemoryCache memoryCache, IMapper mapper, IFileProvider fileProvider)
        {

            //assign
            this.generateTokenService = generateTokenService;
            this.userManager = userManager;
            this.emailService = emailService;
            this.appDbContext = appDbContext;
            this.roleManager = roleManager;
            this.memoryCache = memoryCache;
            this.fileProvider = fileProvider;
            this.mapper = mapper;


            //
            users = new RegisterRepositries(userManager, generateTokenService, emailService, appDbContext);
            ControllingUsers = new AdminControllingUsers(appDbContext, roleManager);
            Student = new StudentRepositries(appDbContext, this.memoryCache);
            Teacher = new TeacherRepositries(appDbContext, this.memoryCache);
            Course = new CourseRepositries(appDbContext, this.memoryCache);
            SubCourse = new SubCourseRepositries(appDbContext, this.memoryCache, this.mapper, this.fileProvider);
            note = new NoteRepositries(appDbContext, this.memoryCache);
            support = new supportRepositries(appDbContext, this.memoryCache);


        }


    }
}

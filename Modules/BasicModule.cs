using Autofac;
using Autofac.Core;
using SharpNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Modules
{
    public class BasicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NoteService>().As<INoteService>().SingleInstance();
            builder.RegisterType<AuthService>().As<IAuthService>().SingleInstance();
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Recruiters
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<InMemoryDatabase>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }


    public class InMemoryDatabase
    {
        private readonly IList<Candidate> _candidates = new List<Candidate>
        {
            new Candidate { Name = "Leeroy", Email = "leeroy@whatever.com", Initials = "L" }
        };


        public void Add(Candidate candidate)
        {
            if (_candidates.Any(x => x.Name.ToLower() == candidate.Name.ToLower()))
                throw new ArgumentException("Already exist in DB");

            _candidates.Add(candidate);
        }

        public IList<Candidate> GetAll()
            => _candidates;

        public Candidate GetByName(string name)
            => _candidates.SingleOrDefault(x => x.Name.ToLower() == name.ToLower());

    }

    public class Candidate
    {
        public string Name { get; set; }
        public string Initials { get; set; }
        public string Email { get; set; }
    }
}

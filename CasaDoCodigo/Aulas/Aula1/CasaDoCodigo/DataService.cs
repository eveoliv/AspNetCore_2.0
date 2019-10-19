using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo
{
    public partial class Startup
    {
        class DataService : IDataService
        {
            private readonly ApplicationContext context;

            public DataService(ApplicationContext context)
            {
                this.context = context;
            }

            public void InicializaDB()
            {
                context.Database.Migrate();

                var json = File.ReadAllText("livors.json");
                var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            }
        }
    }

    class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

    }
}

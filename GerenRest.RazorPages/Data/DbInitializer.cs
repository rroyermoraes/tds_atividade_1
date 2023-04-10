using GerenRest.RazorPages.Models;

namespace GerenRest.RazorPages.Data {
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if(context.Events!.Any()) {
                return;
            }

            var events = new EventModel[] {
                new EventModel {
                    Name = "Torneio de Truco",
                    Description = "Campeonato acadêmico de CC da UTFPR",
                    Date = DateTime.Parse("2023-04-03")
                }
            };

            context.AddRange(events);
            context.SaveChanges();
        }
    }
}
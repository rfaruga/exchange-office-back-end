using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLiteWebApi.Data;

namespace SQLiteWebApi.Models
{
    public class Data
    {
        public static void Initialize(ApplicationDbContext db)
        {
            if (!db.Currencies.Any())
            {
                db.Currencies.Add(new Currency
                {
                    CurrencyName = "PLN",
                    ExchangeRate = 1.0
                });
                db.Currencies.Add(new Currency
                {
                    CurrencyName = "USD",
                    ExchangeRate = 3.7
                });
                db.Currencies.Add(new Currency
                {
                    CurrencyName = "EUR",
                    ExchangeRate = 4.2
                });
                db.Currencies.Add(new Currency
                {
                    CurrencyName = "GBP",
                    ExchangeRate = 4.9
                });
                db.SaveChanges();
            }
        }
    }
}

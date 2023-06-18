﻿using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using Platformy_Programowania_1.Models;
using Platformy_Programowania_1.Services.Interfaces;
using System.Diagnostics;

namespace Platformy_Programowania_1.Services
{
    public class DailyService : IDailyService
    {
        private readonly AppDbContext _dbContext;
        public DailyService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateDaily(DailyData daily)
        {
            _dbContext.Daily.Add(daily);
            await _dbContext.SaveChangesAsync();
            return daily.ID_rekordu;
        }
        public async Task<int> UpdateDaily(DailyData daily)
        {
            _dbContext.Daily.Update(daily);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteDaily(int? id)
        {
            if (id == null)
                return 0;

            var daily = await _dbContext.Daily.FindAsync(id);
            if (daily == null)
                return 0;

            _dbContext.Daily.Remove(daily);
            return await _dbContext.SaveChangesAsync();
        }
        public DailyData GetDailyById(int id)
        {
            return _dbContext.Daily.Find(id);
        }
        public async Task<IEnumerable<DailyData>> GetDailysByCompanyId(int id)
        {
            return await _dbContext.Daily
                .Where(h => h.ID_firmy == id)
                .ToListAsync();
        }
        public async Task<List<YearlyData>> GetDailysAsYearlys(int id)
        {
            List<YearlyData> yearlyData = new List<YearlyData>();
            var dailys = await GetDailysByCompanyId(id);
            foreach (var item in dailys)
            {
                YearlyData yearly = new YearlyData();
                yearly.ID_firmy = item.ID_firmy;
                yearly.ID_rekordu = item.ID_rekordu;
                yearly.Cena = item.Cena;
                yearly.Dzien = DateTime.Today;
                yearly.Dzien = yearly.Dzien.Add(item.Godzina);
                yearlyData.Add(yearly);
            }
            return yearlyData;
        }

        public async Task<int> New_Daily(int id_firmy)
        {
            DailyData New_Data = new DailyData();
            New_Data.ID_firmy = id_firmy;

            //var comp_data = await _dbContext.Companies.Where(h => h.ID_firmy == id_firmy);

            var comp_data = _dbContext.Companies.Find(id_firmy);


            string name = comp_data.Nazwa_firmy.ToString();

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "wwwroot\\scripts\\StockAPI.py";
            start.Arguments = string.Format("\"{0}\" \"{1}\" \"{2}\" \"{3}\"", name, DateTime.Now.ToString("yyyy'-'MM'-'dd"), true, true);
            start.UseShellExecute = false;// Do not use OS shell
            start.CreateNoWindow = true; // We don't need new window
            start.RedirectStandardOutput = true;// Any output, generated by application will be redirected back
            start.RedirectStandardError = true;
            string result;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd();
                    result = reader.ReadToEnd();
                }
            }
            New_Data.Cena = (float)Convert.ToDouble(result);
            New_Data.Godzina = DateTime.Now.TimeOfDay;

            await CreateDaily( New_Data );
            return 0;
        }
    }
}
